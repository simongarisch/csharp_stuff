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
    /// Interaction logic for textbox_adv_topics.xaml
    /// </summary>
    public partial class textbox_adv_topics : Window
    {
        public textbox_adv_topics()
        {
            InitializeComponent();
        }

        private void zoom_in_butt_Click(object sender, RoutedEventArgs e)
        {
           
            if (this.tbox_ctl.FontSize + 4 <100)
            {
                this.tbox_ctl.FontSize = this.tbox_ctl.FontSize + 4;
            }
        }

        private void zoom_out_butt_Click(object sender, RoutedEventArgs e)
        {
            if (this.tbox_ctl.FontSize - 4>6) 
            { 
                this.tbox_ctl.FontSize = this.tbox_ctl.FontSize - 4;
            }
           
        }

        private void sel_all_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Focus();
            this.tbox_ctl.SelectAll();
        }

        private void undo_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Undo();
        }

        private void redo_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Redo();
        }

        private void copy_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Copy();
        }

        private void cut_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Cut();
        }

        private void paste_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.Paste();
        }

        private void disable_wrap_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            this.tbox_ctl.TextWrapping = TextWrapping.NoWrap;
        }

        private void enable_wrap_butt_Click(object sender, RoutedEventArgs e)
        {
            this.tbox_ctl.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            this.tbox_ctl.TextWrapping = TextWrapping.Wrap;
        }
    }
}
