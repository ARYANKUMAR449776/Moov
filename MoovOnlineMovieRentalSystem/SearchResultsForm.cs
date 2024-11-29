using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoovOnlineMovieRentalSystem
{
    public partial class SearchResultsForm : Form
    {
        private List<Movie> _movies;

        public SearchResultsForm(List<Movie> movies)
        {
            InitializeComponent();
            _movies = movies;
            LoadResults();
        }

        private void LoadResults()
        {
            // Clear previous results (if any)
            flwSearchResults.Controls.Clear();

            foreach (var movie in _movies)
            {
                PictureBox moviePictureBox = new PictureBox
                {
                    Size = new Size(150, 200),
                    Cursor = Cursors.Hand,
                    Tag = movie.Title, // Store movie title for click event
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                // Attempt to download and display the image
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
                    catch
                    {
                        // If image fails to load, leave the PictureBox without an image.
                        moviePictureBox.BackColor = Color.Gray;
                    }
                }

                moviePictureBox.Click += MoviePictureBox_Click;
                flwSearchResults.Controls.Add(moviePictureBox);
            }
        }

        private void MoviePictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            string movieTitle = clickedPictureBox?.Tag.ToString();

            if (!string.IsNullOrEmpty(movieTitle))
            {
                // Pass the clicked movie title to MovieDetailForm
                int userID = Login.Session.UserID; // Assume session stores user ID
                MovieDetailForm movieDetailForm = new MovieDetailForm(movieTitle, userID);
                movieDetailForm.ShowDialog(); // Show MovieDetailForm
            }
        }
    }

}
