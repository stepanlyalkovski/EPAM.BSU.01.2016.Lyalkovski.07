using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    public class Clock
    {
        private TimeSpan time = new TimeSpan();
        public event EventHandler<EventArgs> TimeIsOver = delegate { };

        protected virtual void OnTimeIsOver(object sender, EventArgs e)
        {
            TimeIsOver(sender, e);
        }

        public void SetCountDown(int seconds)
        {
            time = TimeSpan.FromSeconds(seconds);
        }

        public void TurnOn()
        {
            Thread thread = new Thread(Ticks);
            thread.Start();
        }

        public void Ticks()
        {
            double timeRemaining = time.TotalSeconds;

            while (timeRemaining > 0)
            {
                timeRemaining--;
                Thread.Sleep(1000);
                //Debug.WriteLine(timeRemaning);
            }
            OnTimeIsOver(this, EventArgs.Empty);
        }

    }
}
