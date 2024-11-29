// CODE WITHOUT CATEGORIES YET
//using System;
//using System.Data.SqlClient;
//using System.Drawing;
//using System.IO;
//using System.Net;
//using System.Windows.Forms;

//namespace MoovOnlineMovieRentalSystem
//{
//    public partial class MainForm : Form
//    {
//        private string connectionString = "Data source = ANGEL\\SQLEXPRESS; Initial Catalog = MoovRentalDB; Integrated Security = True";
//        public MainForm()
//        {
//            InitializeComponent();
//            LoadMovies();
//        }

//        private void LoadMovies()
//        {
//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                conn.Open();
//                string query = "SELECT Title, ImagePath FROM Movies";
//                SqlCommand cmd = new SqlCommand(query, conn);

//                using (SqlDataReader reader = cmd.ExecuteReader())
//                {
//                    int xPos = 10;  // Starting X position
//                    int yPos = 10;  // Starting Y position

//                    while (reader.Read())
//                    {
//                        string title = reader["Title"].ToString();
//                        string imageUrl = reader["ImagePath"].ToString();

//                        PictureBox moviePictureBox = new PictureBox
//                        {
//                            Size = new Size(150, 200), // Set default size
//                            Cursor = Cursors.Hand,
//                            Tag = title, // Store title in Tag for easy access on click
//                            SizeMode = PictureBoxSizeMode.Zoom, // Ensure the image fits within the PictureBox while maintaining aspect ratio
//                            BackColor = Color.Transparent // Make PictureBox background transparent
//                        };

//                        // Download and display the image
//                        using (var client = new WebClient())
//                        {
//                            try
//                            {
//                                byte[] imageBytes = client.DownloadData(imageUrl);
//                                using (var stream = new MemoryStream(imageBytes))
//                                {
//                                    Image movieImage = Image.FromStream(stream);
//                                    moviePictureBox.Image = movieImage; // Assign the image directly to PictureBox
//                                }
//                            }
//                            catch (Exception ex)
//                            {
//                                MessageBox.Show($"Error loading image for {title}: {ex.Message}");
//                            }
//                        }

//                        // Add click event to show the title on click
//                        moviePictureBox.Click += MoviePictureBox_Click;

//                        // Set the location of the PictureBox (dynamic placement)
//                        moviePictureBox.Location = new Point(xPos, yPos);

//                        // Add the PictureBox to the form or a panel
//                        this.Controls.Add(moviePictureBox);

//                        // Ensure the PictureBox is placed at the front
//                        moviePictureBox.BringToFront();

//                        // Adjust the position for the next PictureBox
//                        xPos += moviePictureBox.Width + 10;  // Add space between the images
//                        if (xPos > this.Width - 150) // Move to the next row if out of bounds
//                        {
//                            xPos = 10;
//                            yPos += moviePictureBox.Height + 10;
//                        }
//                    }
//                }
//            }
//        }

//        private void MoviePictureBox_Click(object sender, EventArgs e)
//        {
//            PictureBox clickedPictureBox = sender as PictureBox;
//            string movieTitle = clickedPictureBox?.Tag.ToString();

//            if (movieTitle != null)
//            {
//                MessageBox.Show($"Movie Title: {movieTitle}", "Movie Details");
//            }
//        }
//    }
//}


// WITH CATEGORIES


using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace MoovOnlineMovieRentalSystem
{
    public partial class MainForm : Form
    {
        private string connectionString = "Data source = ARYANSROG\\SQLEXPRESS; Initial Catalog = MoovRentalDB; Integrated Security = True";
        private Dictionary<Button, (Color BackColor, Color ForeColor, FlatStyle FlatStyle)> designerStyles;
        public MainForm()
        {
            InitializeComponent();
            LoadMovies();
            PopulateComboBoxes();
            this.AutoScroll = true; // allow scrolling
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

        private void LoadMovies()
        {
            string[] categories = new string[]
            {
            "Trending Movies", "People's Choice", "Movie Suggestions", "Most Rented Movies", "Unreleased Movies"
            };

            int yOffset = 230;
            int xOffset = 210;
            List<Movie> allMovies = new List<Movie>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Title, ImagePath, Category FROM Movies";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string title = reader["Title"].ToString();
                    string imageUrl = reader["ImagePath"].ToString();
                    string movieCategory = reader["Category"].ToString();

                    allMovies.Add(new Movie
                    {
                        Title = title,
                        ImagePath = imageUrl,
                        Category = movieCategory
                    });
                }
                reader.Close();
            }

            foreach (var category in categories)
            {
                // print categories as labels
                Label categoryLabel = new Label
                {
                    Text = category,
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(440, yOffset)
                };
                this.Controls.Add(categoryLabel);

                // display movie images
                FlowLayoutPanel moviePanel = new FlowLayoutPanel
                {
                    Location = new Point(xOffset, yOffset),
                    Size = new Size(650, 250),
                    AutoScroll = true,
                    WrapContents = true,
                    FlowDirection = FlowDirection.LeftToRight
                };
                this.Controls.Add(moviePanel);

                yOffset += 300;

                foreach (var movie in allMovies)
                {
                    if (movie.Category == category)
                    {
                        PictureBox moviePictureBox = new PictureBox
                        {
                            Size = new Size(150, 200),
                            Cursor = Cursors.Hand,
                            Tag = movie.Title,
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };

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

                        moviePictureBox.Click += MoviePictureBox_Click;
                        moviePanel.Controls.Add(moviePictureBox);
                    }
                }
            }




        }

        private int GetLoggedInUserID()
        {
            return Login.Session.UserID; // return the session UserID
        }


        private void MoviePictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            string movieTitle = clickedPictureBox?.Tag.ToString();

            if (movieTitle != null)
            {
                // pass the movie title and user ID to MovieDetailForm
                int userID = GetLoggedInUserID(); // get the current logged-in user's ID
                MovieDetailForm movieDetailForm = new MovieDetailForm(movieTitle, userID);
                movieDetailForm.ShowDialog(); // show MovieDetailForm 
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide(); // hide current form (MainForm)

            LandingPage landingPage = new LandingPage();
            landingPage.ShowDialog(); // open Landing Page upon sign out.
        }

        private void btnUserProfile_Click(object sender, EventArgs e)
        {
            int userID = GetLoggedInUserID(); // retrieve the current logged-in user's ID
            UserProfileForm userProfileForm = new UserProfileForm(userID);
            userProfileForm.ShowDialog(); // show the user profile form
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string artist = txtArtist.Text.Trim();
            string genre = cmbGenre.SelectedItem?.ToString();
            string tag = cmbTags.SelectedItem?.ToString();

            List<Movie> searchResults = new List<Movie>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();


                    if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(artist) && string.IsNullOrEmpty(genre) && string.IsNullOrEmpty(tag))
                    {
                        MessageBox.Show("Please provide input to search");
                        return;
                    }
                    else
                    {
                        // Build the WHERE clause dynamically
                        List<string> conditions = new List<string>();
                        if (!string.IsNullOrEmpty(title)) conditions.Add("Title LIKE @Title");
                        if (!string.IsNullOrEmpty(artist)) conditions.Add("ArtistName LIKE @Artist");
                        if (!string.IsNullOrEmpty(genre)) conditions.Add("Genre = @Genre");
                        if (!string.IsNullOrEmpty(tag)) conditions.Add("Tag LIKE @Tag");

                        string query = "SELECT Title, ImagePath, Category FROM Movies";
                        if (conditions.Count > 0) query += " WHERE " + string.Join(" AND ", conditions);

                        SqlCommand cmd = new SqlCommand(query, conn);

                        // Add parameters to prevent SQL injection
                        if (!string.IsNullOrEmpty(title)) cmd.Parameters.AddWithValue("@Title", "%" + title + "%");
                        if (!string.IsNullOrEmpty(artist)) cmd.Parameters.AddWithValue("@Artist", "%" + artist + "%");
                        if (!string.IsNullOrEmpty(genre)) cmd.Parameters.AddWithValue("@Genre", genre);
                        if (!string.IsNullOrEmpty(tag)) cmd.Parameters.AddWithValue("@Tag", "%" + tag + "%");

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            searchResults.Add(new Movie
                            {
                                Title = reader["Title"].ToString(),
                                ImagePath = reader["ImagePath"].ToString(),
                                Category = reader["Category"].ToString()
                            });
                        }
                    }
                }

                // Display the results in a new form if results are found
                if (searchResults.Count > 0)
                {
                    SearchResultsForm resultsForm = new SearchResultsForm(searchResults);
                    resultsForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No movies match the search criteria.", "Search Results");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Search Error");
            }
        }

        private void PopulateComboBoxes()
        {

            // Add the genres
            cmbGenre.Items.Add("Action");
            cmbGenre.Items.Add("Fantasy");
            cmbGenre.Items.Add("Animation");
            cmbGenre.Items.Add("Sci-Fi");

            // Add the tags
            cmbTags.Items.Add("Superhero");
            cmbTags.Items.Add("Adventure");
            cmbTags.Items.Add("Family");
            cmbTags.Items.Add("Fantasy");
            cmbTags.Items.Add("Thriller");


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

        private void txtArtist_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the 'Enter' key was pressed
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the default action (e.g., clearing the text)
                e.Handled = true;

                // Trigger the login button click event programmatically
                btnSearch.PerformClick();
            }
        }

        private void txtTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the default action (e.g., clearing the text)
                e.Handled = true;

                // Trigger the login button click event programmatically
                btnSearch.PerformClick();
            }
        }

        private void cmbGenre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the default action (e.g., clearing the text)
                e.Handled = true;

                // Trigger the login button click event programmatically
                btnSearch.PerformClick();
            }
        }

        private void cmbTags_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the default action (e.g., clearing the text)
                e.Handled = true;

                // Trigger the login button click event programmatically
                btnSearch.PerformClick();
            }
        }
    }


}



// movie class that holds movie data.
// MARM: @Aryan, we can update this one to add more parameters if needed.
public class Movie
{
    public string Title { get; set; }
    public string ImagePath { get; set; }
    public string Category { get; set; }
}