using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ShutdownTimer
{
    public class TimerPlusPlus
    {
        private Timer _timer;
        private double _numberOfIterations;
        private int _iterCounter = 0;

        public TimerPlusPlus()
        {
            _timer = new Timer();
            _timer.Elapsed += Timer_OnElapsed;
        }

        private void Timer_OnElapsed(object sender, ElapsedEventArgs e)
        {
            Timer timer = sender as Timer;
            _iterCounter++;
            if (_iterCounter == _numberOfIterations)
            {
                _timer.Stop();
            }
        }

        public double IntervalForTick
        {
            get;
            set;
        }
        public double Interval
        {
            get;
            set;
        }

        public void Start()
        {
            _timer.Interval = IntervalForTick;
            _numberOfIterations = Interval / IntervalForTick;
            _timer.Start();
        }


    }
}
