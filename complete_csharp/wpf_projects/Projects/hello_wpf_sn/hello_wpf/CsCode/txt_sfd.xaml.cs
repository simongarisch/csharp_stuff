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
    /// Interaction logic for txt_sfd.xaml
    /// </summary>
    public partial class txt_sfd : Window
    {
        public txt_sfd()
        {
            InitializeComponent();
        }

        private void save_butt_Click(object sender, RoutedEventArgs e)
        {
            System.IO.File.WriteAllText("E:\\tuts\\info.txt", this.txt_tbox.Text,Encoding.UTF8);
            MessageBox.Show("Done!","Alert");
        }

        private void load_butt_Click(object sender, RoutedEventArgs e)
        {
          this.txt_tbox.Text=  System.IO.File.ReadAllText("E:\\tuts\\info.txt", Encoding.UTF8);
            
        }

        private void new_butt_Click(object sender, RoutedEventArgs e)
        {
            txt_tbox.Text = "";
            txt_tbox.Focus();
        }

        private void save_as_butt_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog sf = new Microsoft.Win32.SaveFileDialog();
            //-----common freatures-----------------
            sf.Title = "Save Text File";
            sf.Filter = "Text Files|*.txt";
            //sf.InitialDirectory = "E:\\tuts";
            sf.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            sf.AddExtension = true;
            //--------------------------------------
            sf.ShowDialog();
            // MessageBox.Show(sf.FileName);
            ////////// if (sf.FileName=="") 
            ////////// {
            //////////     return;
            ////////// }
            //////////System.IO.File.WriteAllText(sf.FileName, this.txt_tbox.Text, Encoding.UTF8);
            //////////MessageBox.Show("Done!", "Alert");
            if (sf.FileName != "")
            {
                System.IO.File.WriteAllText(sf.FileName, this.txt_tbox.Text, Encoding.UTF8);
                MessageBox.Show("Done!", "Alert");
            }
         

        }
    }
}
