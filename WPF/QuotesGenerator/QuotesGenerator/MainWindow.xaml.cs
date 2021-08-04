using System.Windows;
using QuotesGenerator.Quotes;


namespace QuotesGenerator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetNextQuote(object sender, RoutedEventArgs e)
        {
            var quotes = new Quotes.Quotes();
            QuoteText.Text = quotes.GetRandomQuote();
        }
    }
}
