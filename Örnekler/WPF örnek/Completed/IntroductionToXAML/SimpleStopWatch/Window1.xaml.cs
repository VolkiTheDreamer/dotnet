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

namespace SimpleStopWatch
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        WpfStopWatch.Ticker _localTicker;

        public Window1()
        {
            InitializeComponent();
            _localTicker = (WpfStopWatch.Ticker)this.FindResource("localTicker");
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
    }
}
