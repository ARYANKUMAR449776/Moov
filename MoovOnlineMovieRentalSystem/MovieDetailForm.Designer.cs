namespace MoovOnlineMovieRentalSystem
{
    partial class MovieDetailForm
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
            lblMovieTitle = new Label();
            btnRent = new Button();
            btnAddToFavorites = new Button();
            btnPlaceOnHold = new Button();
            SuspendLayout();
            // 
            // lblMovieTitle
            // 
            lblMovieTitle.AutoSize = true;
            lblMovieTitle.Font = new Font("Century Schoolbook", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMovieTitle.Location = new Point(12, 37);
            lblMovieTitle.Name = "lblMovieTitle";
            lblMovieTitle.Size = new Size(63, 21);
            lblMovieTitle.TabIndex = 0;
            lblMovieTitle.Text = "label1";
            // 
            // btnRent
            // 
            btnRent.BackColor = Color.Black;
            btnRent.FlatStyle = FlatStyle.Popup;
            btnRent.Font = new Font("Century Schoolbook", 9F);
            btnRent.ForeColor = Color.White;
            btnRent.Location = new Point(89, 90);
            btnRent.Margin = new Padding(3, 4, 3, 4);
            btnRent.Name = "btnRent";
            btnRent.Size = new Size(86, 44);
            btnRent.TabIndex = 1;
            btnRent.Text = "Rent";
            btnRent.UseVisualStyleBackColor = false;
            // 
            // btnAddToFavorites
            // 
            btnAddToFavorites.BackColor = Color.Black;
            btnAddToFavorites.FlatStyle = FlatStyle.Popup;
            btnAddToFavorites.Font = new Font("Century Schoolbook", 9F);
            btnAddToFavorites.ForeColor = Color.White;
            btnAddToFavorites.Location = new Point(181, 90);
            btnAddToFavorites.Margin = new Padding(3, 4, 3, 4);
            btnAddToFavorites.Name = "btnAddToFavorites";
            btnAddToFavorites.Size = new Size(129, 44);
            btnAddToFavorites.TabIndex = 2;
            btnAddToFavorites.Text = "Add to Favorites";
            btnAddToFavorites.UseVisualStyleBackColor = false;
            // 
            // btnPlaceOnHold
            // 
            btnPlaceOnHold.BackColor = Color.Black;
            btnPlaceOnHold.FlatStyle = FlatStyle.Popup;
            btnPlaceOnHold.Font = new Font("Century Schoolbook", 9F);
            btnPlaceOnHold.ForeColor = Color.White;
            btnPlaceOnHold.Location = new Point(317, 90);
            btnPlaceOnHold.Margin = new Padding(3, 4, 3, 4);
            btnPlaceOnHold.Name = "btnPlaceOnHold";
            btnPlaceOnHold.Size = new Size(129, 44);
            btnPlaceOnHold.TabIndex = 3;
            btnPlaceOnHold.Text = "Place On Hold";
            btnPlaceOnHold.UseVisualStyleBackColor = false;
            // 
            // MovieDetailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(527, 183);
            Controls.Add(btnPlaceOnHold);
            Controls.Add(btnAddToFavorites);
            Controls.Add(btnRent);
            Controls.Add(lblMovieTitle);
            Cursor = Cursors.Hand;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MovieDetailForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MovieDetailForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMovieTitle;
        private Button btnRent;
        private Button btnAddToFavorites;
        private Button btnPlaceOnHold;
    }
}