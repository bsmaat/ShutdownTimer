using System;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ShutdownTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        private Timer _timer = new Timer();

        private bool _shutdown = false;
        private int _numOfIter = 0;
        private int _count;

        public MainWindow()
        {
            InitializeComponent();

            // set the interval to one second
            _timer.Interval = 1000;
            _timer.Elapsed += OnTimedEvent;
        }

        private void BtnSleep_Click(object sender, RoutedEventArgs e)
        {
            _shutdown = false;
        }

        private void BtnShutdownOrSleep_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null)
            {
                return;
            }

            double time;
            if (!TryParseTime(textBox.Text, out time))
            {
                return;
            }

            switch (btn.Name)
            {
                case nameof(btnShutdown):
                    _shutdown = true;
                    break;
                case nameof(btnSleep):
                    _shutdown = false;
                    break;
                default:
                    break;
            }

            btnShutdown.IsEnabled = btnSleep.IsEnabled = false;
            StartTimer(time);
        }

        private double ConvertMinutesToMilliseconds(double time)
        {
            return time * 60 * 1000;
        }

        private void StartTimer(double time)
        {
            _numOfIter = (int)Math.Round(ConvertMinutesToMilliseconds(time) / 1000, MidpointRounding.AwayFromZero);
            _count = 0;
            _timer.Start();
        }

        private void CancelTimer()
        {
            _timer.Stop();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Timer timer = sender as Timer;
            if (sender == null)
            {
                return;
            }

            _count++;

            if (_count == _numOfIter)
            {
                timer.Stop();

                if (_shutdown)
                {
                    ShutdownComputer();
                }
                else
                {
                    SleepComputer();
                }

                Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(
                    () =>
                    {
                        btnShutdown.IsEnabled = btnSleep.IsEnabled = true;
                    }));
            }
          

        }

        private void ShutdownComputer()
        {
            
        }

        private void SleepComputer()
        {
            // Standby
            SetSuspendState(false, true, true);
        }

        private bool TryParseTime(string time, out double val)
        {
            if (!double.TryParse(time, out val))
            {
                return false;
            }

            if (val <= 0)
            {
                return false;
            }

            return true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            btnShutdown.IsEnabled = btnSleep.IsEnabled = true;
        }
    }
}
