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
using System.Windows.Threading;
namespace Task03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Hits { get; set; } = 0;
        int Fails { get; set; } = 0;
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new();
            timer.Tick += OnCharButtonClick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }
        void OnCharButtonClick(object sender, EventArgs args)
        {
            if(button.Visibility == Visibility.Visible)
            {
                button.Visibility = Visibility.Hidden;
            }
            else
            {
                button.Visibility = Visibility.Visible;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Hits += 1;
            hits.Text = Hits.ToString();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Fails += 1;
            fails.Text = Fails.ToString();
        }
    }
}
