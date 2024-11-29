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
    public partial class Favorites : Form
    {
        private int UserID { get; set; }
        private string connectionString = "Data source = ARYANSROG\\SQLEXPRESS; Initial Catalog = MoovRentalDB; Integrated Security = True";


        public Favorites(int userID)
        {
            InitializeComponent();
            UserID = userID;
            LoadFavorites();
            this.AutoScroll = true;
        }

        public void LoadFavorites()
        {
            // Clear all controls first to avoid duplicates
            this.Controls.Clear();

            // Add header label for the section
            Label headerLabel = new Label
            {
                Text = "Your Favorites",
                Font = new Font("Century Schoolbook", 14, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            this.Controls.Add(headerLabel);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Query to fetch the user's favorite movies
                    string query = @"
                SELECT m.MovieID, m.Title, m.Genre, m.ReleaseDate, m.ImagePath
                FROM Favorites f
                INNER JOIN Movies m ON f.MovieID = m.MovieID
                WHERE f.UserID = @UserID
                ORDER BY f.AddedDate DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", UserID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    int yOffset = 50; // To position each movie dynamically
                    while (reader.Read())
                    {
                        // Read movie details
                        int movieId = reader.GetInt32(0);
                        string title = reader.GetString(1);
                        string genre = reader.GetString(2);
                        DateTime releaseDate = reader.GetDateTime(3);
                        string imagePath = reader.GetString(4);

                        // Display movie details
                        Label movieLabel = new Label
                        {
                            Text = $"{title} ({releaseDate.ToString("yyyy")}) - {genre}",
                            Location = new Point(10, yOffset),
                            AutoSize= true,
                            Font = new Font("Century Schoolbook", 10)
                        };
                        this.Controls.Add(movieLabel);

                        // Optional: Display movie image if available
                        if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                        {
                            PictureBox movieImage = new PictureBox
                            {
                                Image = Image.FromFile(imagePath),
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                Location = new Point(400, yOffset),
                                Size = new Size(50, 50)
                            };
                            this.Controls.Add(movieImage);
                        }

                        yOffset += 70; // Increase offset for next movie
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading favorites: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
