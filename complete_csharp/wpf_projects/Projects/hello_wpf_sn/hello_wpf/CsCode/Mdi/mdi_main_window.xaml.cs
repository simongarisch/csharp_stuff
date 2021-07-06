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
using System.Windows.Shapes;

namespace hello_wpf.CsCode.Mdi
{
    /// <summary>
    /// Interaction logic for mdi_main_window.xaml
    /// </summary>
    public partial class mdi_main_window : Window
    {
        public mdi_main_window()
        {
            InitializeComponent();
        }

        private void show_window_butt_Click(object sender, RoutedEventArgs e)
        {
            Mdi_child_window child_win = new Mdi_child_window();
            //hello_wpf.CsCode.Mdi.Mdi_child_window test_win = new hello_wpf.CsCode.Mdi.Mdi_child_window();
           
            child_win.Show();
        }

        private void show_dialog_window_butt_Click(object sender, RoutedEventArgs e)
        {
            Mdi_child_window child_win = new Mdi_child_window();
            //hello_wpf.CsCode.Mdi.Mdi_child_window test_win = new hello_wpf.CsCode.Mdi.Mdi_child_window();
            child_win.ShowDialog();
        }

        private void change_window_butt_Click(object sender, RoutedEventArgs e)
        {
            Mdi_child_window child_win = new Mdi_child_window();
            //---------------------------
            child_win.Title = "Hello! I'm Happy C# Code!";
            child_win.Background = System.Windows.Media.Brushes.LightGreen;
            child_win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            child_win.ResizeMode = ResizeMode.CanResize;
            child_win.WindowState = WindowState.Normal;
            child_win.Width = 600;
            child_win.Height = 500;
            child_win.IsEnabled = true;
            child_win.Visibility = Visibility.Visible;
            //---------change the ctls properties------------------
            child_win.test_lbl.Content = "I changed...";
            child_win.test_lbl.Foreground= System.Windows.Media.Brushes.Red;
            child_win.test_lbl.Background = System.Windows.Media.Brushes.LightBlue;
            //-------------------
            child_win.save_butt.Content = "Saving...";
            //-----------------------------------------------------
            child_win.Show();
        }
    }
}
