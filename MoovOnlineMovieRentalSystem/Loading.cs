namespace MoovOnlineMovieRentalSystem
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
            ConfigureProgressBar();
        }

        private void ConfigureProgressBar()
        {
            barLoading.Minimum = 0; // Starting value
            barLoading.Maximum = 100; // Ending value
            barLoading.Value = 0; // Initial value
            barLoading.Step = 10; // Increment step
        }

        private void UpdateProgress()
        {
            if (barLoading.Value < barLoading.Maximum)
            {
                barLoading.PerformStep(); // Increment progress
            }
            else
            {
                MessageBox.Show("Loading Complete!");
            }
        }

        public void StartLoadingAction(Action loadingAction)
        {
            // Reset the progress bar
            barLoading.Value = 0;

            // Use a Task to perform the action asynchronously
            Task.Run(() =>
            {
                loadingAction?.Invoke();

                // Update the progress bar in the UI thread
                for (int i = 0; i <= 100; i += 10)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        barLoading.Value = i;
                    }));
                    Thread.Sleep(100); // Simulate work
                }

                // Close the form after completion
                Invoke((MethodInvoker)(() =>
                {
                    this.Close();
                }));
            });

            // Show the Loading form modally
            this.ShowDialog();
        }

    }
}
