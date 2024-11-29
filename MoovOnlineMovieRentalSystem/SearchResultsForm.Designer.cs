namespace MoovOnlineMovieRentalSystem
{
    partial class SearchResultsForm
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
            flwSearchResults = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // flwSearchResults
            // 
            flwSearchResults.AutoScroll = true;
            flwSearchResults.Location = new Point(45, 97);
            flwSearchResults.Name = "flwSearchResults";
            flwSearchResults.Size = new Size(743, 449);
            flwSearchResults.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Schoolbook", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(321, 60);
            label1.Name = "label1";
            label1.Size = new Size(164, 24);
            label1.TabIndex = 1;
            label1.Text = "Search Results";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Century Schoolbook", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(133, 54);
            label2.TabIndex = 18;
            label2.Text = "Moov";
            // 
            // SearchResultsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 564);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flwSearchResults);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "SearchResultsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SearchResultsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flwSearchResults;
        private Label label1;
        private Label label2;
    }
}