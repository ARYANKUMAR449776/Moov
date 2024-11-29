namespace MoovOnlineMovieRentalSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    // To customize application configuration such as set high DPI settings or default font,
        //    // see https://aka.ms/applicationconfiguration.
        //    ApplicationConfiguration.Initialize();
        //    Application.Run(new MainForm());
        //}

        // Updated code:
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ////// start with LandingPage Form
            LandingPage landingPageForm = new LandingPage();
            landingPageForm.ShowDialog();

            //using mainform for testing
            //MainForm mainForm = new MainForm();
            //mainForm.ShowDialog();

            // user will have the option to sign up or login
        }
    }
}