using System.Windows;


namespace todolist
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddNewTodo(object sender, RoutedEventArgs e)
        {
            string content = NewItemText.Text;
            if (string.IsNullOrEmpty(content))
            {
                MessageBox.Show("Please enter some text for the TODO");
                return;
            }

            var item = new SingleItem(content);
            TodoStack.Children.Add(item);
        }
    }
}
