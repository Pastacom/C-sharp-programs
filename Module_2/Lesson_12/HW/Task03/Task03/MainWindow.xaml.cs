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

namespace Task03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var textBlock = new TextBlock();
            var stackPanel = new StackPanel();
            var slider = new Slider();
            slider.Minimum = -10; slider.Maximum = 10;
            slider.Orientation = Orientation.Horizontal;
            slider.Margin = new Thickness(10);
            slider.ValueChanged += (s, e) =>
            {
                textBlock.Text = slider.Value.ToString("F2");
            };
            stackPanel.Children.Add(slider);
            textBlock.FontSize = 30;
            textBlock.Background = new SolidColorBrush(Colors.LightGray);
            textBlock.Width = 85;
            HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.Text = "0";
            stackPanel.Children.Add(textBlock);
            Content = stackPanel;
        }
    }
}
