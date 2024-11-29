using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MoovOnlineMovieRentalSystem
{
    public partial class UserProfileForm : Form
    {
        private int UserID { get; set; }
        private Dictionary<Button, (Color BackColor, Color ForeColor, FlatStyle FlatStyle)> designerStyles;

        public UserProfileForm(int userID)
        {
            InitializeComponent();
            UserID = userID;
            // Initialize the dictionary
            designerStyles = new Dictionary<Button, (Color, Color, FlatStyle)>();

            // Attach events and save styles
            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    // Save the designer-applied styles
                    designerStyles[btn] = (btn.BackColor, btn.ForeColor, btn.FlatStyle);

                    // Attach events
                    btn.MouseEnter += btn_MouseEnter;
                    btn.MouseLeave += btn_MouseLeave;
                }
            }
        }
        private void UserProfileForm_Load(object sender, EventArgs e)
        {
            setlabelUserName();
        }


        private int GetLoggedInUserID()
        {
            return Login.Session.UserID;
        }

        private void btnRentedMovies_Click(object sender, EventArgs e)
        {
            int userID = GetLoggedInUserID();
            // debugging 
            //MessageBox.Show($"UserID passed to RentedMovies: {userID}", "Debug UserID", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RentedMovies rentedMoviesForm = new RentedMovies(userID);
            rentedMoviesForm.Show();
        }

        private void btnFavoritesMovies_Click(object sender, EventArgs e)
        {
            int userID = GetLoggedInUserID();
            Favorites favorites = new Favorites(userID);
            favorites.Show();
        }

        private void btnGoBackHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setlabelUserName()
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection()) {
                connection.Open();
                string nameQuery = "Select Username From Users Where UserID=@userID";
                SqlCommand namecommand = new SqlCommand(nameQuery, connection);
                namecommand.Parameters.AddWithValue("@userID", UserID);

               string name = (string)namecommand.ExecuteScalar();
               lblProfileName.Text = name+"'s Profile";
            }
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = Color.Gray;
                btn.ForeColor = Color.Black;
                btn.FlatStyle = FlatStyle.Flat;
            }
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button btn && designerStyles.ContainsKey(btn))
            {
                // Restore the original Designer styles
                var originalStyle = designerStyles[btn];
                btn.BackColor = originalStyle.BackColor;
                btn.ForeColor = originalStyle.ForeColor;
                btn.FlatStyle = originalStyle.FlatStyle;
            }

        }
    } 
}
