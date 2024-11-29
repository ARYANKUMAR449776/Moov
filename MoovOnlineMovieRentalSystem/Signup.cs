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

    public partial class Signup : Form
    {
        private Dictionary<Button, (Color BackColor, Color ForeColor, FlatStyle FlatStyle)> designerStyles;
        public Signup()
        {
            InitializeComponent();
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


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); // Calls the base class OnPaint

            // Get the graphics object to draw on the form
            Graphics g = e.Graphics;

            // Define the size of the triangle
            int triangleWidth = 500; // Change as needed
            int triangleHeight = 450; // Change as needed

            // Define the points for the triangle (bottom-left corner)
            Point[] trianglePoints = new Point[]
            {
            new Point(0, this.ClientSize.Height), // Bottom-left corner
            new Point(triangleWidth, this.ClientSize.Height), // Bottom-right corner
            new Point(0, this.ClientSize.Height - triangleHeight) // Top-left corner
            };

            // Create a black brush
            using (Brush grayBrush = new SolidBrush(Color.DarkGray))
            {
                // Fill the triangle with the black color
                g.FillPolygon(grayBrush, trianglePoints);
            }

        }



        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string email = txtEmail.Text;

            // validation
            if (password != confirmPassword)
            {
                MessageLabel.Text = "Passwords do not match!";
                return;
            }

            string salt = AuthenticationHelper.GenerateSalt();
            string hashedPassword = AuthenticationHelper.HashPassword(password, salt);

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "INSERT INTO Users (Username, PasswordHash, Salt, Email) VALUES (@Username, @PasswordHash, @Salt, @Email)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                command.Parameters.AddWithValue("@Salt", salt);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Registration successful!");

                    this.Hide();

                    // show login form
                    Login loginForm = new Login();
                    loginForm.ShowDialog(); // display login form

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = "Error: " + ex.Message;
                }
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
