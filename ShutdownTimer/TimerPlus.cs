using System;
using System.Timers;

namespace ShutdownTimer
{
    /// <summary>
    /// Class that has additional timer functionality. This was created so that I can get
    /// the time remaining. The class comes from https://stackoverflow.com/questions/2278525/system-timers-timer-how-to-get-the-time-remaining-until-elapse
    /// </summary>
    public class TimerPlus : Timer
    {
        private DateTime _dueTime;
        private double _interval;
        private double _numberOfIters;

        public TimerPlus() : base()
        {
            this.Elapsed += this.ElapsedAction;
        }

        /// <summary>
        /// Gets the remaining time (in milliseconds)
        /// </summary>
        public double TimeLeft
        {
            get
            {            
                return (_dueTime - DateTime.Now).TotalMilliseconds;
            }
        }

        public double IntervalForTick
        {
            get;
            set;
        }

        /*
        public new double Interval
        {
            get
            {
                return 
            }
            set
            {
                // return the time lengtin in milliseconds?
                _interval = value;
                base.Interval = value;
                _numberOfIters = value / IntervalForTick;
            }
        }
        */

        public static int MinutesToMilliseconds(double minutes)
        {
            int millis = (int)(minutes * 60 * 1000);
            return millis;
        }

        public static double MillisecondsToMinute(double millis)
        {
            double mins = millis / (1000 * 60);
            return mins;
        }

        protected new void Dispose()
        {
            this.Elapsed -= this.ElapsedAction;
            base.Dispose();
        }

        private void ElapsedAction(object sender, ElapsedEventArgs e)
        {
            if (this.AutoReset)
            {
                _dueTime = DateTime.Now.AddMilliseconds(Interval);
            }
        }

        public new void Start()
        {
            _dueTime = DateTime.Now.AddMilliseconds(Interval);
            base.Start();
        }


    }
}
