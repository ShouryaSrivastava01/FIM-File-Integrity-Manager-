using System.IO;
using System.Windows;

namespace FileIntegrityMonitoring
{
    public partial class LogViewerWindow : Window
    {
        public LogViewerWindow()
        {
            InitializeComponent();

            // Load and display the log file contents in the TextBox
            LoadLogFile();
        }

        private void LoadLogFile()
        {
            // Get the path to the log file in the project folder
            string projectFolder = System.AppDomain.CurrentDomain.BaseDirectory;
            string logFilePath = Path.Combine(projectFolder, "logfile.txt");

            // Check if the log file exists
            if (File.Exists(logFilePath))
            {
                // Read the contents of the log file and display them in the TextBox
                txtLog.Text = File.ReadAllText(logFilePath);
            }
            else
            {
                txtLog.Text = "Log file not found.";
            }
        }

        

    }
}
