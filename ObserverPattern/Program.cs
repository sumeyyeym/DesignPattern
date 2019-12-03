using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject();
            Observer observer1 = new Observer("Center", subject, "\t\t");
            Observer observer2 = new Observer("Right", subject, "\t,\t,\t,\t,");

            subject.Run();
            observer1.Update("7");
            observer2.Update("7");
            Console.ReadKey();
        }
    }

    public class Simulator : IEnumerable
    {
        string[] moves = { "5", "3", "1", "6", "7" };
        public IEnumerator GetEnumerator()
        {
            foreach (string element in moves)
            {
                yield return element; // yield sayesinde bütün işi otomatik kendisi yapıyo
            }
        }
    }

    public class Subject
    {
        public delegate void CallBack(string s); // birden fazla metodu içerisinde döndürebilen yapı = delegate
        public event CallBack Notify;

        Simulator simulator = new Simulator();
        const int speed = 200;

        public string SubjectState { get; set; }

        public void Go()
        {
            new Thread(new ThreadStart(Run)).Start();
        }

        public void Run()
        {
            foreach (string s in simulator)
            {
                Console.WriteLine("Subject : " + s);
                SubjectState = s;
                Thread.Sleep(speed);
            }
        }
    }


    public interface IObserver
    {
        void Update(string state);
    }

    public class Observer : IObserver
    {
        private string  _name;
        private Subject _subject;
        private string  _state;
        private string  _gap;

        public Observer(string name, Subject subject, string gap)
        {
            this._name = name;
            this._subject = subject;
            this._gap = gap;
            subject.Notify += Update;
        }
        public void Update(string state)
        {
            _state = state;
            Console.WriteLine(_gap + _name + " : " + state);
        }
    }
}
