using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Forms;

namespace MoovOnlineMovieRentalSystem
{
    public partial class RentedMovies : Form
    {
        private int UserID { get; set; }
        private string connectionString = "Data source = ARYANSROG\\SQLEXPRESS; Initial Catalog = MoovRentalDB; Integrated Security = True";

        public RentedMovies(int userID)
        {
            InitializeComponent();
            UserID = userID;
            LoadRentedMovies();
            this.AutoScroll = true;
        }

        //private void LoadRentedMovies()
        //{
        //    // Clear existing controls (labels, pictureboxes, buttons)
        //    //this.Controls.Clear();
        //    this.Controls.Add(new Label() { Text = "Rented Movies", Font = new Font("Arial", 14), Location = new Point(10, 10) });

        //    List<Movie> rentedMovies = new List<Movie>();

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            string query = "SELECT m.Title, m.ImagePath FROM UserRentals ur JOIN Movies m ON ur.RentalID = m.MovieID WHERE ur.UserID = @UserID";
        //            SqlCommand cmd = new SqlCommand(query, conn);
        //            cmd.Parameters.AddWithValue("@UserID", UserID);
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                string title = reader["Title"].ToString();
        //                string imageUrl = reader["ImagePath"].ToString();

        //                rentedMovies.Add(new Movie { Title = title, ImagePath = imageUrl });
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Error loading rented movies: {ex.Message}");
        //        }
        //    }

        //    DisplayRentedMovies(rentedMovies);
        //}

        //private void DisplayRentedMovies(List<Movie> rentedMovies)
        //{
        //    int yOffset = 50; // Adjusted yOffset to avoid overlap with header label

        //    foreach (var movie in rentedMovies)
        //    {
        //        // Create a label for movie title
        //        Label movieLabel = new Label
        //        {
        //            Text = movie.Title,
        //            Font = new Font("Arial", 12),
        //            AutoSize = true,
        //            Location = new Point(10, yOffset)
        //        };
        //        this.Controls.Add(movieLabel);

        //        // Create a PictureBox for movie image
        //        PictureBox moviePictureBox = new PictureBox
        //        {
        //            Size = new Size(150, 200),
        //            SizeMode = PictureBoxSizeMode.StretchImage,
        //            Tag = movie.Title
        //        };

        //        // Load image into PictureBox
        //        using (var client = new WebClient())
        //        {
        //            try
        //            {
        //                byte[] imageBytes = client.DownloadData(movie.ImagePath);
        //                using (var stream = new MemoryStream(imageBytes))
        //                {
        //                    moviePictureBox.Image = Image.FromStream(stream);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show($"Error loading image for {movie.Title}: {ex.Message}");
        //            }
        //        }

        //        // Add the movie image to the form
        //        moviePictureBox.Location = new Point(10, yOffset + 30);
        //        this.Controls.Add(moviePictureBox);

        //        // Create a "Return" button under the movie image
        //        Button returnButton = new Button
        //        {
        //            Text = "Return",
        //            Location = new Point(10, yOffset + 240),
        //            Tag = movie.Title
        //        };

        //        // Event handler for the Return button
        //        returnButton.Click += (sender, e) =>
        //        {
        //            string movieTitleToReturn = (sender as Button)?.Tag.ToString();
        //            if (movieTitleToReturn != null)
        //            {
        //                ReturnMovie(movieTitleToReturn);
        //            }
        //        };

        //        this.Controls.Add(returnButton);
        //        yOffset += 270; // Adjust vertical space for next movie (including button)
        //    }
        //}

        //private void ReturnMovie(string movieTitle)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            string query = "DELETE FROM UserRentals WHERE UserID = @UserID AND RentalID = (SELECT MovieID FROM Movies WHERE Title = @MovieTitle)";
        //            SqlCommand cmd = new SqlCommand(query, conn);
        //            cmd.Parameters.AddWithValue("@UserID", UserID);
        //            cmd.Parameters.AddWithValue("@MovieTitle", movieTitle);

        //            int rowsAffected = cmd.ExecuteNonQuery();
        //            if (rowsAffected > 0)
        //            {
        //                MessageBox.Show($"{movieTitle} has been returned.");
        //                LoadRentedMovies(); // Reload the rented movies after return
        //            }
        //            else
        //            {
        //                MessageBox.Show("Error returning the movie. Please try again.");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error returning movie: {ex.Message}");
        //    }
        //}

        //private void LoadRentedMovies()
        //{
        //    // Clear all controls first to avoid duplicates
        //    this.Controls.Clear();

        //    // Add header label for the section
        //    Label headerLabel = new Label
        //    {
        //        Text = "Rented Movies",
        //        Font = new Font("Arial", 14),
        //        Location = new Point(10, 10),
        //        AutoSize = true
        //    };
        //    this.Controls.Add(headerLabel);

        //    List<Movie> rentedMovies = new List<Movie>();

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            string query = "SELECT m.Title, m.ImagePath FROM UserRentals ur JOIN Movies m ON ur.MovieID = m.MovieID WHERE ur.UserID = @UserID";
        //            SqlCommand cmd = new SqlCommand(query, conn);
        //            cmd.Parameters.AddWithValue("@UserID", UserID);
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                string title = reader["Title"].ToString();
        //                string imageUrl = reader["ImagePath"].ToString();

        //                rentedMovies.Add(new Movie { Title = title, ImagePath = imageUrl });
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Error loading rented movies: {ex.Message}");
        //        }
        //    }

        //    if (rentedMovies.Count == 0)
        //    {
        //        // No rented movies, show the message
        //        Label noMoviesLabel = new Label
        //        {
        //            Text = "No rented movies yet.",
        //            Font = new Font("Arial", 12),
        //            ForeColor = Color.Red,
        //            AutoSize = true,
        //            Location = new Point(10, 50)
        //        };
        //        this.Controls.Add(noMoviesLabel);
        //    }
        //    else
        //    {
        //        // Display the rented movies
        //        DisplayRentedMovies(rentedMovies);
        //    }
        //}

        private void LoadRentedMovies()
        {
            // Clear all controls first to avoid duplicates
            this.Controls.Clear();

            // Add header label for the section
            Label headerLabel = new Label
            {
                Text = "Rented Movies",
                Font = new Font("Century Schoolbook", 14),
                Location = new Point(10, 10),
                AutoSize = true
            };
            this.Controls.Add(headerLabel);

            List<Movie> rentedMovies = new List<Movie>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Adjusted query to correctly join based on MovieTitle
                    string query = @"
                SELECT m.Title, m.ImagePath 
                FROM UserRentals ur 
                JOIN Movies m ON ur.MovieTitle = m.Title 
                WHERE ur.UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string title = reader["Title"].ToString();
                        string imageUrl = reader["ImagePath"].ToString();

                        rentedMovies.Add(new Movie { Title = title, ImagePath = imageUrl });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading rented movies: {ex.Message}");
                }
            }

            if (rentedMovies.Count == 0)
            {
                // No rented movies, show the message
                Label noMoviesLabel = new Label
                {
                    Text = "No rented movies yet.",
                    Font = new Font("Century Schoolbook", 12),
                    ForeColor = Color.Red,
                    AutoSize = true,
                    Location = new Point(10, 50)
                };
                this.Controls.Add(noMoviesLabel);
            }
            else
            {
                // Display the rented movies
                DisplayRentedMovies(rentedMovies);
            }
        }


        private void DisplayRentedMovies(List<Movie> rentedMovies)
        {
            int yOffset = 50; // Start below the header label

            foreach (var movie in rentedMovies)
            {
                // Create a label for movie title
                Label movieLabel = new Label
                {
                    Text = movie.Title,
                    Font = new Font("Century Schoolbook", 12),
                    AutoSize = true,
                    Location = new Point(10, yOffset)
                };
                this.Controls.Add(movieLabel);

                // Create a PictureBox for movie image
                PictureBox moviePictureBox = new PictureBox
                {
                    Size = new Size(150, 200),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = movie.Title
                };

                // Load image into PictureBox
                using (var client = new WebClient())
                {
                    try
                    {
                        byte[] imageBytes = client.DownloadData(movie.ImagePath);
                        using (var stream = new MemoryStream(imageBytes))
                        {
                            moviePictureBox.Image = Image.FromStream(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image for {movie.Title}: {ex.Message}");
                    }
                }

                // Add the movie image to the form
                moviePictureBox.Location = new Point(10, yOffset + 30);
                this.Controls.Add(moviePictureBox);

                // Create a "Return" button under the movie image
                Button returnButton = new Button
                {
                    Text = "Return",
                    Location = new Point(10, yOffset + 240),
                    Tag = movie.Title,
                    Font = new Font("Century Schoolbook", 9),
                    Size = new Size(86, 31),
                    BackColor = Color.Black,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Popup,

                };

                // Event handler for the Return button
                returnButton.Click += (sender, e) =>
                {
                    string movieTitleToReturn = (sender as Button)?.Tag.ToString();
                    if (movieTitleToReturn != null)
                    {
                        ReturnMovie(movieTitleToReturn);
                    }
                };

                this.Controls.Add(returnButton);
                yOffset += 270; // Adjust vertical space for next movie (including button)
            }
        }

        //private void ReturnMovie(string movieTitle)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            string query = "DELETE FROM UserRentals WHERE UserID = @UserID AND RentalID = (SELECT MovieID FROM Movies WHERE Title = @MovieTitle)";
        //            SqlCommand cmd = new SqlCommand(query, conn);
        //            cmd.Parameters.AddWithValue("@UserID", UserID);
        //            cmd.Parameters.AddWithValue("@MovieTitle", movieTitle);

        //            int rowsAffected = cmd.ExecuteNonQuery();
        //            if (rowsAffected > 0)
        //            {
        //                MessageBox.Show($"{movieTitle} has been returned.");
        //                LoadRentedMovies(); // Reload the rented movies after return
        //            }
        //            else
        //            {
        //                MessageBox.Show("Error returning the movie. Please try again.");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error returning movie: {ex.Message}");
        //    }
        //}

        private void ReturnMovie(string movieTitle)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Correct the query by using the RentalID, which uniquely identifies each rental
                    string query = @"
                DELETE FROM UserRentals 
                WHERE UserID = @UserID 
                AND MovieTitle = @MovieTitle 
                AND RentalID = (
                    SELECT TOP 1 RentalID 
                    FROM UserRentals 
                    WHERE UserID = @UserID 
                    AND MovieTitle = @MovieTitle
                    ORDER BY RentalDate DESC
                )";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@MovieTitle", movieTitle);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {

                        string setStateQuery = "UPDATE Movies SET _state = 0 where Title = @SetStateFromMovieTitle;";
                        SqlCommand setState = new SqlCommand(setStateQuery, conn);
                        setState.Parameters.AddWithValue("@SetStateFromMovieTitle", movieTitle);
                        setState.ExecuteNonQuery();


                        MessageBox.Show($"{movieTitle} has been returned.");
                        LoadRentedMovies(); // Reload the rented movies after return
                    }
                    else
                    {
                        MessageBox.Show("Error returning the movie. Please try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( MessageBoxIcon.Error + $"Error returning movie: {ex.Message}");
            }
        }


        private void MoviePictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            string movieTitle = clickedPictureBox?.Tag.ToString();

            //if (movieTitle != null)
            //{
            //    // Open MovieDetailForm for clicked movie
            //    MovieDetailForm movieDetailForm = new MovieDetailForm(movieTitle, UserID);
            //    movieDetailForm.ShowDialog();
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
