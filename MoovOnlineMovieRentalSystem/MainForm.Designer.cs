namespace MoovOnlineMovieRentalSystem
{
    partial class MainForm
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
            MoviePictureBox = new PictureBox();
            btnLogout = new Button();
            btnUserProfile = new Button();
            btnSearch = new Button();
            txtTitle = new TextBox();
            txtArtist = new TextBox();
            cmbTags = new ComboBox();
            cmbGenre = new ComboBox();
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            label2 = new Label();
            label3 = new Label();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)MoviePictureBox).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // MoviePictureBox
            // 
            MoviePictureBox.BackColor = Color.Transparent;
            MoviePictureBox.Location = new Point(505, 291);
            MoviePictureBox.Margin = new Padding(3, 4, 3, 4);
            MoviePictureBox.Name = "MoviePictureBox";
            MoviePictureBox.Size = new Size(126, 129);
            MoviePictureBox.TabIndex = 2;
            MoviePictureBox.TabStop = false;
            MoviePictureBox.Visible = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Black;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Century Schoolbook", 9F);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(8, 129);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(181, 36);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnUserProfile
            // 
            btnUserProfile.BackColor = Color.Black;
            btnUserProfile.Cursor = Cursors.Hand;
            btnUserProfile.FlatStyle = FlatStyle.Flat;
            btnUserProfile.Font = new Font("Century Schoolbook", 9F);
            btnUserProfile.ForeColor = Color.White;
            btnUserProfile.Location = new Point(8, 85);
            btnUserProfile.Margin = new Padding(3, 4, 3, 4);
            btnUserProfile.Name = "btnUserProfile";
            btnUserProfile.Size = new Size(181, 36);
            btnUserProfile.TabIndex = 4;
            btnUserProfile.Text = "User Profile";
            btnUserProfile.UseVisualStyleBackColor = false;
            btnUserProfile.Click += btnUserProfile_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Black;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatStyle = FlatStyle.Popup;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(410, 205);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(368, 36);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtTitle
            // 
            txtTitle.BorderStyle = BorderStyle.None;
            txtTitle.Location = new Point(410, 39);
            txtTitle.Multiline = true;
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Movie Title";
            txtTitle.Size = new Size(368, 27);
            txtTitle.TabIndex = 6;
            txtTitle.KeyDown += txtTitle_KeyDown;
            // 
            // txtArtist
            // 
            txtArtist.BorderStyle = BorderStyle.None;
            txtArtist.Location = new Point(410, 75);
            txtArtist.Multiline = true;
            txtArtist.Name = "txtArtist";
            txtArtist.PlaceholderText = "Artist Name";
            txtArtist.Size = new Size(368, 27);
            txtArtist.TabIndex = 7;
            txtArtist.KeyDown += txtArtist_KeyDown;
            // 
            // cmbTags
            // 
            cmbTags.FormattingEnabled = true;
            cmbTags.Location = new Point(587, 153);
            cmbTags.Name = "cmbTags";
            cmbTags.Size = new Size(151, 28);
            cmbTags.TabIndex = 9;
            cmbTags.KeyDown += cmbTags_KeyDown;
            // 
            // cmbGenre
            // 
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Location = new Point(587, 119);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(151, 28);
            cmbGenre.TabIndex = 10;
            cmbGenre.KeyDown += cmbGenre_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Century Schoolbook", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(33, 13);
            label1.Name = "label1";
            label1.Size = new Size(133, 54);
            label1.TabIndex = 17;
            label1.Text = "Moov";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(410, 99);
            panel1.Name = "panel1";
            panel1.Size = new Size(368, 2);
            panel1.TabIndex = 20;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(410, 64);
            panel2.Name = "panel2";
            panel2.Size = new Size(368, 2);
            panel2.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Schoolbook", 9F);
            label2.Location = new Point(454, 122);
            label2.Name = "label2";
            label2.Size = new Size(131, 18);
            label2.TabIndex = 22;
            label2.Text = "Search By Genre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Schoolbook", 9F);
            label3.Location = new Point(471, 157);
            label3.Name = "label3";
            label3.Size = new Size(113, 18);
            label3.TabIndex = 23;
            label3.Text = "Search By Tag:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(btnUserProfile);
            panel3.Controls.Add(btnLogout);
            panel3.Location = new Point(-1, 1);
            panel3.Name = "panel3";
            panel3.Size = new Size(195, 2250);
            panel3.TabIndex = 24;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(998, 600);
            Controls.Add(panel3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(cmbGenre);
            Controls.Add(cmbTags);
            Controls.Add(txtArtist);
            Controls.Add(txtTitle);
            Controls.Add(btnSearch);
            Controls.Add(MoviePictureBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)MoviePictureBox).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel movieFlowLayoutPanel;
        private PictureBox MoviePictureBox;
        private Label label1;
        private Button btnLogout;
        private Button btnUserProfile;
        private Button btnSearch;
        private TextBox txtTitle;
        private TextBox txtArtist;
        private ComboBox cmbTags;
        private ComboBox cmbGenre;
        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private Label label3;
        private Panel panel3;
    }
}