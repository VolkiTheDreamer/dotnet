using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace WpfStopWatch
{
    /// <summary>
    /// This class is a simple time ticker class.  Note: this
    /// class is for the include demo only and would require
    /// modifications before using in a production application
    /// </summary>
    public class Ticker : FrameworkElement
    {
        private DispatcherTimer tmr;
        private DateTime startTime;

        #region Dependency Properties
        public static readonly DependencyProperty CurrentIntervalProperty =
            DependencyProperty.Register("CurrentInterval", typeof(TimeSpan), typeof(Ticker), null);

        public TimeSpan CurrentInterval
        {
            get { return (TimeSpan)GetValue(CurrentIntervalProperty); }
            set { SetValue(CurrentIntervalProperty, value); }
        }

        public static readonly DependencyProperty DisplayIntervalProperty =
                    DependencyProperty.Register("DisplayInterval", typeof(string), typeof(Ticker), null);

        public string DisplayInterval
        {
            get { return (string)GetValue(DisplayIntervalProperty); }
            set { SetValue(DisplayIntervalProperty, value); }
        }

        public new bool IsEnabled
        {
            get { return tmr.IsEnabled; }
        }
        #endregion

        public Ticker()
        {
            tmr = new DispatcherTimer();
            tmr.Interval = new TimeSpan(0, 0, 0, 0, 100);
            tmr.Tick += new EventHandler(tmr_Tick);
            UpdateValues(true);
        }

        public void Start()
        {
            if (!tmr.IsEnabled)
            {
                startTime = DateTime.Now - CurrentInterval;
                tmr.Start();
            }
        }

        public void Stop()
        {
            if (tmr.IsEnabled)
                tmr.Stop();
        }

        public void Clear()
        {
            startTime = DateTime.Now;
            UpdateValues(true);
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            UpdateValues(false);
        }

        private void UpdateValues(bool reset)
        {
            if (reset)
                CurrentInterval = new TimeSpan();
            else
                CurrentInterval = DateTime.Now - startTime;
            DisplayInterval = string.Format("{0:D2}:{1:D2}", CurrentInterval.Minutes, CurrentInterval.Seconds);
        }
    }
}
