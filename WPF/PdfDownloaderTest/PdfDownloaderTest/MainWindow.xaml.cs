using System.Windows;
using System.Windows.Media; // for Brush and BrushConverter


namespace PdfDownloaderTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static BrushConverter converter = new BrushConverter();
        private static Brush red = (Brush)converter.ConvertFromString("#d9534f");
        private static Brush green = (Brush)converter.ConvertFromString("#5cb85c");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Fetch_Click(object sender, RoutedEventArgs e)
        {
            lblFinalMessage.Content = "";
            lstDowloads.Items.Clear();

            string url = txtURL.Text;
            if (url.Length == 0)
            {
                lblFeedback.Foreground = red;
                lblFeedback.Content = "A URL with length > 0 is required";
                return;
            }

            lblFeedback.Foreground = green;
            lblFeedback.Content = $"Fetching URL '{url}'...";

            for (int i=1; i<=100; i++)
            {
                lstDowloads.Items.Add($"Item {i} downloaded");
            }

            lblFinalMessage.Foreground = green;
            lblFinalMessage.Content = "Download Complete";
        }
    }
}
