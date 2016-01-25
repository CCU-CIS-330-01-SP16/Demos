using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture6Demos
{
    public class Animal
    {
        public event EventHandler<EventArgs> Running;

        public event EventHandler<EventArgs> Stopped;

        public Status Status { get; set; }

        public Nullable<DateTime> BirthDate { get; set; }

        public void Run()
        {
            Status = Status.Running;
            OnRunning();

            //throw new InvalidOperationException("I tripped!");
        }

        public void Stop()
        {
            Status = Status.Stopped;
            OnStopped();
        }

        private void OnRunning()
        {
            if(Running != null)
            {
                Running(this, new EventArgs());
            }
        }

        private void OnStopped()
        {
            if(Stopped != null)
            {
                Stopped(this, new EventArgs());
            }
        }
    }
}
