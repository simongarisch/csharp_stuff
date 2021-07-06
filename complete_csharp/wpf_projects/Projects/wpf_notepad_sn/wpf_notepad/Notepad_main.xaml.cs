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

namespace wpf_notepad
{
    /// <summary>
    /// Interaction logic for Notepad_main.xaml
    /// </summary>
    public partial class Notepad_main : Window
    {
        public Notepad_main()
        {
            InitializeComponent();
        }

        private void new_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Text = "";
            this.tbox_ctl.Focus();
        }

        private void open_butt_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            //-------------
            ofd.Filter = "Text Files|*.txt";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //-------------
            ofd.ShowDialog();
            //---------------
            
            if (ofd.FileName!="") 
            {
              this.tbox_ctl.Text=  System.IO.File.ReadAllText(ofd.FileName, Encoding.UTF8);
            }
        }

        private void save_butt_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog sf = new Microsoft.Win32.SaveFileDialog();
            //-------------
            sf.Filter = "Text Files|*.txt";
            sf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sf.AddExtension = true;
            //-------------
            sf.ShowDialog();
            //---------------
            if (sf.FileName!="") 
            {
                System.IO.File.WriteAllText(sf.FileName, this.tbox_ctl.Text, Encoding.UTF8);
                MessageBox.Show("Done!");
            }
        }

        private void exit_butt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void undo_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Undo();
        }

        private void redo_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Redo();
        }

        private void cut_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Cut();
        }

        private void copy_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Copy();
        }

        private void paste_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Paste();
        }

        private void sel_all_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Focus();
            this.tbox_ctl.SelectAll();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void word_wrap_butt_Click(object sender, RoutedEventArgs e)
        {
            if (this.word_wrap_butt.IsChecked==true) 
            {
                this.tbox_ctl.TextWrapping = TextWrapping.Wrap;
                this.tbox_ctl.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            }
            else
            {
                this.tbox_ctl.TextWrapping = TextWrapping.NoWrap;
                this.tbox_ctl.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            }
        }

        private void zoom_in_butt_Click(object sender, RoutedEventArgs e)
        {
         
            if (this.tbox_ctl.FontSize + 4<100) 
            {
                this.tbox_ctl.FontSize = this.tbox_ctl.FontSize + 4;
            }
        }

        private void zoom_out_butt_Click(object sender, RoutedEventArgs e)
        {
           
            if (this.tbox_ctl.FontSize - 4>7) 
            {
                this.tbox_ctl.FontSize = this.tbox_ctl.FontSize - 4;
            }
        }

        private void default_zoom_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.FontSize = 15;
        }

        private void about_butt_Click(object sender, RoutedEventArgs e)
        {
            wpf_notepad.about_us ab = new about_us();
            ab.ShowDialog();
        }
    }
}
