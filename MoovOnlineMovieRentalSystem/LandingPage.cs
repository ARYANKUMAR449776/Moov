
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoovOnlineMovieRentalSystem
{
    public partial class LandingPage : Form
    {
        private Dictionary<Button, (Color BackColor, Color ForeColor, FlatStyle FlatStyle)> designerStyles;
        public LandingPage()
        {
            InitializeComponent();


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

            this.BackgroundImage = Image.FromFile("C:\\Bow Valley College\\Soft Dev\\3. Semester 3\\Rapid Application Development\\Project\\MoovOnlineMovieRentalSystem Images\\LandingPageImage.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Resize += MyformResizeBackImage;
        }

        private void MyformResizeBackImage(object sender, EventArgs e)
        {
            // Ensures that the background image stays stretched to the form's new size
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();

            Signup signupForm = new Signup();
            signupForm.ShowDialog();

            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login loginForm = new Login();
            loginForm.ShowDialog();

            this.Close();
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
