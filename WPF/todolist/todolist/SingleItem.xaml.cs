using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace todolist
{
    public partial class SingleItem : UserControl
    {
        private string _content;

        public SingleItem(string content)
        {
            _content = content;
            if (string.IsNullOrEmpty(_content))
            {
                string[] options = new string[] { "Do the dishes", "Cook some bacon", "Practice more WPF", "Browse Reddit" };
                int index = new Random().Next(0, options.Count());
                _content = options[index];
            }

            InitializeComponent();
            this.Loaded += new RoutedEventHandler(OnLoaded);
        }

        public SingleItem(): this(null)
        {
        }

        void OnLoaded(object sender, RoutedEventArgs e)
        {
            TodoLabel.Content = _content;
        }

        private void Remove(object sender, MouseButtonEventArgs e)
        {
            ((Panel)this.Parent).Children.Remove(this);
        }
    }
}
