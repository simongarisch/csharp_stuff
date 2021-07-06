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

namespace hello_wpf.CsCode
{
    /// <summary>
    /// Interaction logic for practical_cs_code.xaml
    /// </summary>
    public partial class practical_cs_code : Window
    {
        public practical_cs_code()
        {
            InitializeComponent();
        }

        private void return_butt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi!");
            MessageBox.Show("Hi! 1");
            return;
           // MessageBox.Show("Hi! 2");
           
        }

        private void close_window_butt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //Practical_cs_code_window.Close();
        }

        private void close_app_butt_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            //Environment.Exit(0);
        }

        private void app_folder_butt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(System.AppDomain.CurrentDomain.BaseDirectory);
        }

        private void special_folders_butt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(System.Environment.GetFolderPath(Environment.SpecialFolder.System));
        }

        private void run_fix_app_butt_Click(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Process.Start("C:\\Windows\\System32\\calc.exe");
            //System.Diagnostics.Process.Start("C:\\Windows\\System32\\mspaint.exe");
            //System.Diagnostics.Process.Start("C:\\Users\\Rec User\\source\\repos\\cs\\hello_wpf_sn\\hello_wpf\\bin\\Debug\\my_pic\\koala_resized.jpg");
            System.Diagnostics.Process.Start("C:\\Users\\Rec User\\source\\repos\\cs\\hello_wpf_sn\\hello_wpf\\bin\\Debug\\my_pic\\");
        }

        private void run_app_dir_butt_Click(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory + "\\calc.exe");
            //System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory + "\\mspaint.exe");
            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory + "\\my_pic\\koala_resized.jpg");
            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory + "\\my_pic\\");
        }

        private void run_special_folder_butt_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(System.Environment.GetFolderPath(Environment.SpecialFolder.System)+"\\calc.exe");
            System.Diagnostics.Process.Start(System.Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\mspaint.exe");
        }
    }
}
