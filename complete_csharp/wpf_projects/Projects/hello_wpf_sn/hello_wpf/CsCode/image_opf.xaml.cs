using Microsoft.Win32;
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
    /// Interaction logic for image_opf.xaml
    /// </summary>
    public partial class image_opf : Window
    {
        public image_opf()
        {
            InitializeComponent();
        }

        private void load_image_butt_Click(object sender, RoutedEventArgs e)
        {
            //---------------------------------
            if (this.file_name_lbl.Content.ToString()=="")
            {
                MessageBox.Show("Please select the image file!");
                return;
            }
            //---------------------------------
            //Uri image_path = new Uri("E:\\a\\wpf_cs\\My_Images\\v.jpg");
            Uri image_path = new Uri(this.file_name_lbl.Content.ToString());
            this.image_ctl.Source = new BitmapImage(image_path);
        }

        private void fill_butt_Click(object sender, RoutedEventArgs e)
        {
            this.image_ctl.Stretch = System.Windows.Media.Stretch.Fill;
        }

        private void zoom_butt_Click(object sender, RoutedEventArgs e)
        {
            this.image_ctl.Stretch = System.Windows.Media.Stretch.Uniform;
        }

        private void browse_butt_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new OpenFileDialog();
            //-------------------------
            ofd.Title = "Select Image to Show";
            ofd.Filter = "JPG Files|*.jpg|PNG Files|*.png|Image Files(*.BMP;*.JPG;*.PNG)|*.bmp;*.jpg;*.png";
            //ofd.Filter = "JPG Files|*.jpg|PNG Files|*.png|Image Files(*.BMP;*.JPG;*.PNG)|*.bmp;*.jpg;*.png|All Files|*.*";
            //--------------------
            //ofd.InitialDirectory = "C:\\utills";
            ofd.InitialDirectory =System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) ;
            //-------------------------
            ofd.ShowDialog();
            // MessageBox.Show(ofd.FileName);
            this.file_name_lbl.Content = ofd.FileName;
        }
    }
}
