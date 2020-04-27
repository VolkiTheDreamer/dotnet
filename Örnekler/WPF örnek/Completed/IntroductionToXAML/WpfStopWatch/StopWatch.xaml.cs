using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WpfStopWatch
{
    /// <summary>
    /// Interaction logic for StopWatch.xaml
    /// </summary>
    public partial class StopWatch : Window
    {
        Ticker _localTicker;

        public StopWatch()
        {
            InitializeComponent();
            _localTicker = (Ticker)this.FindResource("localTicker");
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            _localTicker.Start();
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            _localTicker.Stop();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            _localTicker.Clear();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            //Opacity = 0.6;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Opacity = 1;
        }
    }
}
