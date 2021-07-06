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
    /// Interaction logic for txt_info_project.xaml
    /// </summary>
    public partial class txt_info_project : Window
    {
        public txt_info_project()
        {
            InitializeComponent();
        }

        private void save_butt_Click(object sender, RoutedEventArgs e)
        {
            //------id Guard----------------
            if (this.id_tbox.Text=="") 
            {
                MessageBox.Show("The Id is Empty!", "Alert");
                return;
            }
            //------fn Guard----------------
            if (this.Fname_tbox.Text == "")
            {
                MessageBox.Show("The First Name is Empty!", "Alert");
                return;
            }
            //------ln Guard----------------
            if (this.Lname_tbox.Text == "")
            {
                MessageBox.Show("The Last Name is Empty!", "Alert");
                return;
            }
            //------------------------------
            System.IO.File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory+"\\data\\"+  this.id_tbox.Text+"_info_fn.jpg", this.Fname_tbox.Text, Encoding.UTF8);
            System.IO.File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory + "\\data\\" + this.id_tbox.Text+"_info_ln.jpg", this.Lname_tbox.Text, Encoding.UTF8);
            MessageBox.Show("Done!", "Alert");
        }

        private void search_butt_Click(object sender, RoutedEventArgs e)
        {
            //------id Guard----------------
            if (this.search_id_tbox.Text == "")
            {
                MessageBox.Show("The search Id is empty!", "Alert");
                return;
            }
            //-----------------------
            this.Fname_tbox.Text = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "\\data\\" + this.search_id_tbox.Text + "_info_fn.jpg", Encoding.UTF8);
            this.Lname_tbox.Text = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "\\data\\" + this.search_id_tbox.Text + "_info_ln.jpg", Encoding.UTF8);
            this.id_tbox.Text = this.search_id_tbox.Text;
            //---------------------
        }

        private void new_butt_Click(object sender, RoutedEventArgs e)
        {
            this.Fname_tbox.Text = "";
            this.Lname_tbox.Text = "";
            this.id_tbox.Text = "";
            //-------------
            this.id_tbox.Focus();
        }
    }
}
