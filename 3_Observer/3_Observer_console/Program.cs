using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Observer_console
{
    class Program
    {
        static void Main(string[] args)
        {
            ObserverA obA = new ObserverA();
            ObserverB obB = new ObserverB();

            Subject subJect = new Subject();
            subJect.AddObserver(obA);
            subJect.AddObserver(obB);

            Console.WriteLine(obA._state);
            Console.WriteLine(obA._state);

            subJect.NotifyObservers();

            Console.WriteLine(obA._state);
            Console.WriteLine(obA._state);

        }
    }

    interface IObserver
    {
        void Update();
    }
    class Subject
    {
        private List<IObserver> observers = new List<IObserver>();

        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void NotifyObservers()
        {
            foreach(var o in observers)
            {
                o.Update();
            }
        }
    }

    class ObserverA : IObserver
    {
        public string _state = "none";
        public void Update()
        {
            _state = "A updated";
        }
    }

    class ObserverB : IObserver
    {
        public string _state = "none";
        public void Update()
        {
            _state = "B updated";
        }
    }
}
