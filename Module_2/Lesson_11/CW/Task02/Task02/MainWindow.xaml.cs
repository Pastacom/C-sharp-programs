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

namespace Task02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button newButton = new Button();
            newButton.Width = 100;
            newButton.Height = 50;
            newButton.Content = "Показать текст";
            newButton.HorizontalAlignment = HorizontalAlignment.Right;
            newButton.VerticalAlignment = VerticalAlignment.Center;
            layout.Children.Add(newButton);
            newButton.Click += button_Click;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(textBox.Text);
        }
    }
}
