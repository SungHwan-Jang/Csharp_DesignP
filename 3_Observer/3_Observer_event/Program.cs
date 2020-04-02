using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Observer_event
{
    class Program
    {
        static void Main(string[] args)
        {
            Observer ob = new Observer();
            ob.Test();

            while (true)
            {
                ;
            }
        }
    }

    class Subject
    {
        public event EventHandler Changed;

        public Subject()
        {
            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            
        }

        private void Timer_Elapsed(object sender, EventArgs e)
        {
            if(Changed != null)
            {
                Changed(this, EventArgs.Empty);
            }
        }
    }

    class Observer
    {
        private Subject subject = new Subject();
        private string status;

        public void Test()
        {
            subject.Changed += Subject_Changed;
        }

        private void Subject_Changed(object sender, EventArgs e)
        {
            status = "Subject updated at " + DateTime.Now;
            Debug.WriteLine(status);
        }
    }
}
