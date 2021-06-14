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

namespace WpfLayoutsExample
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

        private void StackPanelButton_Click(object sender, RoutedEventArgs e)
        {
            var stackPanelWindow = new WpfLayoutsExample.ExampleWindows.StackPanelWindow();
            stackPanelWindow.Show();
        }

        private void WrapPanelButton_Click(object sender, RoutedEventArgs e)
        {
            var wrapPanelWindow = new WpfLayoutsExample.ExampleWindows.WrapPanelWindow();
            wrapPanelWindow.Show();
        }

        private void DockPanelButton_Click(object sender, RoutedEventArgs e)
        {
            var dockPanelWindow = new WpfLayoutsExample.ExampleWindows.DockPanelWindow();
            dockPanelWindow.Show();
        }

        private void CanvasPanelButton_Click(object sender, RoutedEventArgs e)
        {
            var canvasPanelWindow = new WpfLayoutsExample.ExampleWindows.CanvasPanelWindow();
            canvasPanelWindow.Show();
        }

        private void GridPanelButton_Click(object sender, RoutedEventArgs e)
        {
            var gridPanelWindow = new WpfLayoutsExample.ExampleWindows.GridPanelWindow();
            gridPanelWindow.Show();
        }
    }
}

