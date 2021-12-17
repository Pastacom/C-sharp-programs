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

namespace Task01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button newButton = new Button();
            newButton.Width = 100;
            newButton.Height = 100;
            newButton.Content = "Правая кнопка";
            newButton.HorizontalAlignment = HorizontalAlignment.Right;
            newButton.VerticalAlignment = VerticalAlignment.Center;
            grid.Children.Add(newButton);
            newButton.Click += rightButton_Click;
            newButton.Margin = new Thickness(100, 100, 100, 100);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Левая кнопка нажата");
        }

        private void rightButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Правая кнопка нажата");
        }
    }
}