// https://wpf-tutorial.com/wpf-application/handling-exceptions/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HandlingExceptions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            try
            {
                s.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "A handled exception just occurred: " + ex.Message,
                    "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning
                );
            }

            // now this exception will not be handled
            // we use the App.xaml magic...
            // See DispatcherUnhandledException="Application_DispatcherUnhandledException"
            s.Trim();
        }
    }

    public partial class App: Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
}
