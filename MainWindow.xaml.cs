using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FileIntegrityMonitoring
{
    public partial class MainWindow : Window
    {
        private string selectedDirectory;
        private ObservableCollection<FileChange> fileChanges;

        public MainWindow()
        {
            InitializeComponent();
            fileChanges = new ObservableCollection<FileChange>();
            dgFileChanges.ItemsSource = fileChanges;
        }

        private void btnSelectDirectory_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    selectedDirectory = dialog.SelectedPath;
                }
            }
        }

        private void btnStartMonitoring_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(selectedDirectory))
            {
                System.Windows.MessageBox.Show("Please select a directory to monitor.");
                return;
            }

            System.IO.FileSystemWatcher watcher = new FileSystemWatcher(selectedDirectory);
            watcher.IncludeSubdirectories = true;
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.CreationTime | NotifyFilters.Size;
            watcher.Changed += OnFileChanged;
            watcher.Created += OnFileChanged;
            watcher.Deleted += OnFileChanged;
            watcher.Renamed += OnFileChanged;
            watcher.EnableRaisingEvents = true;
        }

        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            string filePath = e.FullPath;
            string fileHash = CalculateFileHash(filePath);
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logContent = $"{timestamp}-{e.ChangeType} - {filePath}";

            Dispatcher.Invoke(() =>
            {
                fileChanges.Add(new FileChange { FilePath = filePath, ChangeType = e.ChangeType.ToString(), Hash = fileHash });
           
            });

            string projectFolder = AppDomain.CurrentDomain.BaseDirectory;
            string logFilePath = Path.Combine(projectFolder, "logfile.txt");

            File.AppendAllText(logFilePath, logContent + Environment.NewLine);

            File.SetAttributes(logFilePath, File.GetAttributes(logFilePath)| FileAttributes.Hidden);

        }

        private static string CalculateFileHash(string filePath)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hashBytes = sha256.ComputeHash(stream);
                    return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                }
            }
        }

        private void btnViewLog_Click(object sender, RoutedEventArgs e)
        {
            LogViewerWindow logViewer = new LogViewerWindow();
            logViewer.ShowDialog();
        }



    }

    public class FileChange : INotifyPropertyChanged
    {
        public string FilePath { get; set; }
        public string ChangeType { get; set; }
        public string Hash { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
