namespace MoovOnlineMovieRentalSystem
{
    partial class UserProfileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRentedMovies = new Button();
            btnFavoritesMovies = new Button();
            btnClose = new Button();
            lblProfileName = new Label();
            SuspendLayout();
            // 
            // btnRentedMovies
            // 
            btnRentedMovies.BackColor = Color.Black;
            btnRentedMovies.FlatStyle = FlatStyle.Popup;
            btnRentedMovies.Font = new Font("Century Schoolbook", 9F);
            btnRentedMovies.ForeColor = Color.White;
            btnRentedMovies.Location = new Point(25, 71);
            btnRentedMovies.Margin = new Padding(3, 4, 3, 4);
            btnRentedMovies.Name = "btnRentedMovies";
            btnRentedMovies.Size = new Size(258, 37);
            btnRentedMovies.TabIndex = 0;
            btnRentedMovies.Text = "Rented Movies";
            btnRentedMovies.UseVisualStyleBackColor = false;
            btnRentedMovies.Click += btnRentedMovies_Click;
            // 
            // btnFavoritesMovies
            // 
            btnFavoritesMovies.BackColor = Color.Black;
            btnFavoritesMovies.FlatStyle = FlatStyle.Popup;
            btnFavoritesMovies.Font = new Font("Century Schoolbook", 9F);
            btnFavoritesMovies.ForeColor = Color.White;
            btnFavoritesMovies.Location = new Point(25, 116);
            btnFavoritesMovies.Margin = new Padding(3, 4, 3, 4);
            btnFavoritesMovies.Name = "btnFavoritesMovies";
            btnFavoritesMovies.Size = new Size(258, 37);
            btnFavoritesMovies.TabIndex = 1;
            btnFavoritesMovies.Text = "Favorite Movies";
            btnFavoritesMovies.UseVisualStyleBackColor = false;
            btnFavoritesMovies.Click += btnFavoritesMovies_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Black;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.Font = new Font("Century Schoolbook", 9F);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(25, 161);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(258, 37);
            btnClose.TabIndex = 2;
            btnClose.Text = "Go back";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnGoBackHome_Click;
            // 
            // lblProfileName
            // 
            lblProfileName.AutoSize = true;
            lblProfileName.Font = new Font("Century Schoolbook", 11F, FontStyle.Bold);
            lblProfileName.Location = new Point(25, 29);
            lblProfileName.Name = "lblProfileName";
            lblProfileName.Size = new Size(70, 23);
            lblProfileName.TabIndex = 3;
            lblProfileName.Text = "label1";
            // 
            // UserProfileForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(307, 224);
            Controls.Add(lblProfileName);
            Controls.Add(btnClose);
            Controls.Add(btnFavoritesMovies);
            Controls.Add(btnRentedMovies);
            Cursor = Cursors.Hand;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "UserProfileForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UserProfileForm";
            Load += UserProfileForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRentedMovies;
        private Button btnFavoritesMovies;
        private Button btnClose;
        private Label lblProfileName;
    }
}