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
    /// Interaction logic for First_cs.xaml
    /// </summary>
    public partial class First_cs : Window
    {
        public First_cs()
        {
            InitializeComponent();
        }

        private void First_Butt_Click(object sender, RoutedEventArgs e)
        {
            /*System.Windows.MessageBox.Show("Hello world this is my first C# code!");
            System.Windows.MessageBox.Show("line 2");
            System.Windows.MessageBox.Show("line 3");*/
        }

        private void Second_Butt_Click(object sender, RoutedEventArgs e)
        {
            //This will show a message to user
            System.Windows.MessageBox.Show("I'm Button 2!","Hello");
        }

        private void Text_Butt_Click(object sender, RoutedEventArgs e)
        {
            First_cs_window.Title = "Hello Baby!";
            this.Title= "Hello Baby!";
        }

        private void change_content_butt_Click(object sender, RoutedEventArgs e)
        {
            //----------- change button text--------------
            //change_content_butt.Content = "Hello Baby!";
            //----------- change texbox and label text-------
            text_lbl.Content = "I'm Not Baby!";
            //text_tbox.Text = "But I'm Baby! So I'm happy!!!!";
            //----------------------------------------------
            this.change_content_butt.Content = "Hello Baby!";//Using this keyword
            this.text_tbox.Text = "Hi!";//use this keyword!!!!
           
        }

        private void change_window_color_Click(object sender, RoutedEventArgs e)
        {
            this.Background = System.Windows.Media.Brushes.Silver;
            this.main_grid.Background = System.Windows.Media.Brushes.LightPink;
        }

        private void change_ctls_color_Click(object sender, RoutedEventArgs e)
        {
            this.change_window_color.Background = System.Windows.Media.Brushes.Yellow;
            //--------------- change textbox color--------------
            this.text_tbox.Background = System.Windows.Media.Brushes.YellowGreen;
            //--------------------------------------------------
            //-------------- change label color-----------------
            this.text_lbl.Background = System.Windows.Media.Brushes.LightBlue;
            
        }

        private void Change_text_color_butt_Click(object sender, RoutedEventArgs e)
        {
            this.Change_text_color_butt.Foreground = System.Windows.Media.Brushes.Red;
            //-----------------change textbox text color-------------
            this.text_tbox.Foreground = System.Windows.Media.Brushes.OrangeRed;
            //-------------------------------------------------------
            //-----------------change label text color-------------
            this.text_lbl.Foreground = System.Windows.Media.Brushes.OrangeRed;
            //-------------------------------------------------------
        }

        private void Disable_enable_butt_Click(object sender, RoutedEventArgs e)
        {
            this.change_ctls_color.IsEnabled = false;
            this.sub_grid.IsEnabled = false;
            //this.IsEnabled = false;
            //--------------------
           // this.Enable_butt.IsEnabled = true;
        }

        private void Enable_butt_Click(object sender, RoutedEventArgs e)
        {
            this.sub_grid.IsEnabled = true;
            
        }

        private void hide_butt_Click(object sender, RoutedEventArgs e)
        {
            this.Change_text_color_butt.Visibility =Visibility.Hidden;
            //-------------------------
            this.sub_grid.Visibility = Visibility.Hidden;
            //-------------------------
            //this.Visibility = Visibility.Hidden;
        }

        private void show_butt_Click(object sender, RoutedEventArgs e)
        {
            this.Change_text_color_butt.Visibility = Visibility.Visible;
            //-------------------------
            this.sub_grid.Visibility = Visibility.Visible;
           // this.Visibility = Visibility.Visible;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            image_opf w = new image_opf();
            w.ShowDialog();
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            practical_cs_code w = new practical_cs_code();
            w.ShowDialog();
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            txt_sfd w = new txt_sfd();
            w.ShowDialog();
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            txt_info_project w = new txt_info_project();
            w.ShowDialog();
        }

        private void b3_Copy_Click(object sender, RoutedEventArgs e)
        {
             menu_ctl w = new menu_ctl();
            w.ShowDialog();
        }
    }
}
