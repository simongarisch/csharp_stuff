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
using Microsoft.Win32;


// https://wpf-tutorial.com/dialogs/the-openfiledialog/
// https://wpf-tutorial.com/dialogs/the-savefiledialog/
// https://wpf-tutorial.com/dialogs/the-other-dialogs/
// https://wpf-tutorial.com/dialogs/creating-a-custom-input-dialog/
namespace OpenFileDialogExample
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

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txtEditor.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
            }
        }
    }
}
