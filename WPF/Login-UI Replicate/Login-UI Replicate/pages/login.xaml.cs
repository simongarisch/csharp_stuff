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

namespace Login_UI_Replicate.pages
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page
    {
        MainWindow mainWindow { get => Application.Current.MainWindow as MainWindow; }

        public login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Credentials: " + usernameBox.Text + " " + passwordBox.Password);
            string relativePath = "pages/landing.xaml";
            mainWindow.mainFrame.Navigate(new Uri(relativePath), UriKind.RelativeOrAbsolute);
        }
    }
}
