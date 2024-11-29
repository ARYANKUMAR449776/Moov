using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoovOnlineMovieRentalSystem
{
    public partial class Login : Form
    {
        private Dictionary<Button, (Color BackColor, Color ForeColor, FlatStyle FlatStyle)> designerStyles;
        public Login()
        {
            InitializeComponent();
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

        public static class Session
        {
            public static int UserID { get; private set; }

            public static void SetUserID(int userID)
            {
                UserID = userID;
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); // Calls the base class OnPaint

            // Get the graphics object to draw on the form
            Graphics g = e.Graphics;

            // Define the size of the triangle
            int triangleWidth = 500; // Change as needed
            int triangleHeight = 450; // Change as needed

            // Define the points for the triangle (bottom-right corner)
            Point[] trianglePoints = new Point[]
            {
            new Point(this.ClientSize.Width, this.ClientSize.Height), // Bottom-right corner
            new Point(this.ClientSize.Width - triangleWidth, this.ClientSize.Height), // Bottom-left corner
            new Point(this.ClientSize.Width, this.ClientSize.Height - triangleHeight) // Top-right corner
            };

            // Create a black brush
            using (Brush grayBrush = new SolidBrush(Color.DarkGray))
            {
                // Fill the triangle with the black color
                g.FillPolygon(grayBrush, trianglePoints);
            }
        }


        //private void btnLogin_Click(object sender, EventArgs e)
        //{
        //    string username = txtUserName.Text;
        //    string password = txtPassword.Text;

        //    using (SqlConnection connection = DatabaseHelper.GetConnection())
        //    {
        //        string query = "SELECT PasswordHash, Salt FROM Users WHERE Username = @Username";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("@Username", username);

        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            string storedHash = reader["PasswordHash"].ToString();
        //            string storedSalt = reader["Salt"].ToString();
        //            string hashedPassword = AuthenticationHelper.HashPassword(password, storedSalt);

        //            if (hashedPassword == storedHash)
        //            {
        //                MessageBox.Show("Login successful!");
        //                this.Hide();

        //                // Show main form
        //                MainForm mainForm = new MainForm();
        //                mainForm.ShowDialog();

        //                this.Close();
        //            }
        //            else
        //            {
        //                MessageLabel.Text = "Invalid username or password.";
        //            }
        //        }
        //        else
        //        {
        //            MessageLabel.Text = "Invalid username or password.";
        //        }
        //    }
        //}

        private void PerformTaskWithLoading()
        {
            // Create an instance of the Loading form
            Loading loadingForm = new Loading();

            // Define the task to be performed
            Action task = () =>
            {
                // Simulate a long-running task
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000); // Simulate work
                }
            };

            // Start the loading action
            loadingForm.StartLoadingAction(task);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT UserID, PasswordHash, Salt FROM Users WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int userID = Convert.ToInt32(reader["UserID"]);
                    string storedHash = reader["PasswordHash"].ToString();
                    string storedSalt = reader["Salt"].ToString();
                    string hashedPassword = AuthenticationHelper.HashPassword(password, storedSalt);

                    if (hashedPassword == storedHash)
                    {
                        // Store the UserID in Session for access across the app
                        Session.SetUserID(userID);

                        //show loading bar
                        PerformTaskWithLoading();
                        //show sucessfull login
                        MessageBox.Show("Login successful!");
                        this.Hide();

                        // Show main form
                        MainForm mainForm = new MainForm();
                        mainForm.ShowDialog();

                        this.Close();

                    }
                    else
                    {
                        MessageLabel.Text = "Invalid username or password.";

                    }
                }
                else
                {
                    MessageLabel.Text = "Invalid username or password.";

                }
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the 'Enter' key was pressed
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the default action (e.g., clearing the text)
                e.Handled = true;

                // Trigger the login button click event programmatically
                btnLogin.PerformClick();
            }
        }



        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the default action (e.g., clearing the text)
                e.Handled = true;

                // Trigger the login button click event programmatically
                btnLogin.PerformClick();
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
