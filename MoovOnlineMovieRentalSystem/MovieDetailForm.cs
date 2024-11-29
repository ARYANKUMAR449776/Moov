//using System;
//using System.Data.SqlClient;
//using System.Windows.Forms;

//namespace MoovOnlineMovieRentalSystem
//{
//    public partial class MovieDetailForm : Form
//    {
//        private string connectionString = "Data source = ANGEL\\SQLEXPRESS; Initial Catalog = MoovRentalDB; Integrated Security = True";
//        public string MovieTitle { get; set; }
//        private int UserID { get; set; } // User ID to associate with rental

//        public MovieDetailForm(string movieTitle, int userID)
//        {
//            InitializeComponent();
//            MovieTitle = movieTitle;
//            UserID = userID;
//            lblMovieTitle.Text = $"Movie Title: {movieTitle}";
//            btnRent.Click += BtnRent_Click;
//        }

//        private void BtnRent_Click(object sender, EventArgs e)
//        {
//            // Rent the movie logic
//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    conn.Open();

//                    // Check how many movies the user has rented
//                    string countQuery = "SELECT COUNT(*) FROM UserRentals WHERE UserID = @UserID";
//                    SqlCommand countCmd = new SqlCommand(countQuery, conn);
//                    countCmd.Parameters.AddWithValue("@UserID", UserID);
//                    int rentedMoviesCount = (int)countCmd.ExecuteScalar();

//                    // Enforce the limit of 4 rented movies
//                    if (rentedMoviesCount >= 4)
//                    {
//                        MessageBox.Show("You can only rent up to 4 movies", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    }
//                    else
//                    {
//                        // Rent the movie (if under the limit)
//                        string rentQuery = "INSERT INTO UserRentals (UserID, MovieTitle) VALUES (@UserID, @MovieTitle)";
//                        SqlCommand rentCmd = new SqlCommand(rentQuery, conn);
//                        rentCmd.Parameters.AddWithValue("@UserID", UserID);
//                        rentCmd.Parameters.AddWithValue("@MovieTitle", MovieTitle);
//                        int rowsAffected = rentCmd.ExecuteNonQuery();

//                        if (rowsAffected > 0)
//                        {
//                            MessageBox.Show($"You have successfully rented: {MovieTitle}", "Rental Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        }
//                        else
//                        {
//                            MessageBox.Show("Error renting the movie. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }

//            this.Close(); // Close the custom form after renting the movie
//        }
//    }
//}


using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MoovOnlineMovieRentalSystem
{
    public partial class MovieDetailForm : Form
    {
        private string connectionString = "Data source = ARYANSROG\\SQLEXPRESS; Initial Catalog = MoovRentalDB; Integrated Security = True";
        public string MovieTitle { get; set; }
        private int UserID { get; set; }


        public MovieDetailForm(string movieTitle, int userID)
        {
            InitializeComponent();
            MovieTitle = movieTitle;
            UserID = userID;

            lblMovieTitle.Text = $"Movie Title: {movieTitle}";

            // event handlers for rent button, add to favorites button, place on hold button
            btnRent.Click += BtnRent_Click;
            btnAddToFavorites.Click += BtnAddToFavorites_Click;
            btnPlaceOnHold.Click += BtnPlaceOnHold_Click;

      

            SetButtonVisibility();
  
        }

        private void SetButtonVisibility()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // query to check release status and category
                    string query = @"
                            SELECT ReleaseDate, Category 
                            FROM Movies 
                            WHERE Title = @MovieTitle";


                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MovieTitle", MovieTitle);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime releaseDate = reader.GetDateTime(reader.GetOrdinal("ReleaseDate"));
                            string categoryName = reader.GetString(reader.GetOrdinal("Category"));

                            // check release status
                            if (releaseDate > DateTime.Now || categoryName == "Unreleased Movies")
                            {
                                // if movie is not released yet, hide rent button
                                btnRent.Visible = false;
                                btnPlaceOnHold.Visible = true;
                                btnAddToFavorites.Visible = true;
                            }
                            else
                            {
                                // if movie is already released, show rent button
                                btnRent.Visible = true;
                                btnPlaceOnHold.Visible = true;
                                btnAddToFavorites.Visible = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Movie details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Close(); // Close the form if movie details are missing
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void BtnRent_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
             


                    conn.Open();

                    // get the MovieID for the selected movie title
                    string movieIdQuery = "SELECT MovieID FROM Movies WHERE Title = @MovieTitle";
                    SqlCommand movieIdCmd = new SqlCommand(movieIdQuery, conn);
                    movieIdCmd.Parameters.AddWithValue("@MovieTitle", MovieTitle);
                    object movieIdObj = movieIdCmd.ExecuteScalar();

                    if (movieIdObj == null)
                    {
                        MessageBox.Show("Movie not found. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    int movieId = (int)movieIdObj;


                    //statecheck query
                    string stateQuery = "SELECT _state FROM Movies WHERE MovieID = @GetStateFromMovieId;";
                    SqlCommand stateCheck = new SqlCommand(stateQuery, conn);
                    stateCheck.Parameters.AddWithValue("@GetStateFromMovieId", movieId);
                    int state = (int)stateCheck.ExecuteScalar();

                    // check if the movie is on hold by another user
                    string holdQuery = "SELECT COUNT(*) FROM OnHoldMovies WHERE MovieID = @MovieID AND UserID != @UserID";
                    SqlCommand holdCmd = new SqlCommand(holdQuery, conn);
                    holdCmd.Parameters.AddWithValue("@MovieID", movieId);
                    holdCmd.Parameters.AddWithValue("@UserID", UserID);
                    int onHoldCount = (int)holdCmd.ExecuteScalar();

                    if (state == 0 && onHoldCount==0)
                    {

                        // check how many movies the user has rented
                        string countQuery = "SELECT COUNT(*) FROM UserRentals WHERE UserID = @UserID";
                        SqlCommand countCmd = new SqlCommand(countQuery, conn);
                        countCmd.Parameters.AddWithValue("@UserID", UserID);
                        int rentedMoviesCount = (int)countCmd.ExecuteScalar();

                        // enforce the limit of 4 rented movies
                        if (rentedMoviesCount >= 4)
                        {
                            MessageBox.Show("You can only rent up to 4 movies", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }


                            // rent the movie (if under the limit and not on hold)
                            string rentQuery = "INSERT INTO UserRentals (UserID, MovieTitle) VALUES (@UserID, (SELECT Title FROM Movies WHERE MovieID = @MovieID))";


                            SqlCommand rentCmd = new SqlCommand(rentQuery, conn);
                            rentCmd.Parameters.AddWithValue("@UserID", UserID);
                            rentCmd.Parameters.AddWithValue("@MovieID", movieId);
                            int rowsAffected = rentCmd.ExecuteNonQuery();


                            if (rowsAffected > 0)
                            {
                                
                                string setStateQuery = "UPDATE Movies SET _state = 1 where MovieID = @SetStateFromMovieId;";
                                SqlCommand setState = new SqlCommand(setStateQuery, conn);
                                setState.Parameters.AddWithValue("@SetStateFromMovieId", movieId);
                                setState.ExecuteNonQuery();

                                MessageBox.Show($"You have successfully rented: {MovieTitle}", "Rental Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                            {
                                MessageBox.Show("Error renting the movie. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        

                        

                    }
                    else if (onHoldCount > 0)
                    {

                        MessageBox.Show("This movie is currently on hold by another user and cannot be rented.", "Hold Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Movie is already being rented by someone else .");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.Close();
        }

        private void BtnAddToFavorites_Click(object sender, EventArgs e)
        {
            // add movie to favorites
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Favorites (UserID, MovieID, AddedDate) VALUES (@UserID, (SELECT MovieID FROM Movies WHERE Title = @MovieTitle), GETDATE())";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@MovieTitle", MovieTitle);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Successfully added '{MovieTitle}' to your favorites!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to add the movie to favorites. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.Close();
        }

        private void BtnPlaceOnHold_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

               
                try
                {
                    conn.Open();

                    // check if the movie is already on hold
                    string checkQuery = "SELECT COUNT(*) FROM OnHoldMovies WHERE MovieID = (SELECT MovieID FROM Movies WHERE Title = @MovieTitle)";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@MovieTitle", MovieTitle);

                    int holdCount = (int)checkCmd.ExecuteScalar();


                    //statecheck query
                    string stateQuery = "SELECT _state FROM Movies WHERE Title = @MovieTitle;";
                    SqlCommand stateCheck = new SqlCommand(stateQuery, conn);
                    stateCheck.Parameters.AddWithValue("@MovieTitle", MovieTitle);
                    int state = (int)stateCheck.ExecuteScalar();

                    if (holdCount > 0 || state != 0)
                    {
                        // if the movie is already on hold by someone else, show an alert
                        MessageBox.Show($"The movie '{MovieTitle}' is already on hold or being rented by another user.", "Hold Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // otherwise, place the movie on hold
                        string query = "INSERT INTO OnHoldMovies (UserID, MovieID, HoldDate) VALUES (@UserID, (SELECT MovieID FROM Movies WHERE Title = @MovieTitle), GETDATE())";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@MovieTitle", MovieTitle);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"The movie '{MovieTitle}' has been placed on hold.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to place the movie on hold. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.Close();
        }
     

    }
}
