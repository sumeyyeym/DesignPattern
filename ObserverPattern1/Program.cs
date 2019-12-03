using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern1
{
    class Program
    {
        static void Main(string[] args)
        {
            Auctioneer auctioneer = new Auctioneer();
            auctioneer.Attach(new Bidder(auctioneer, "1. Gözlemeci"));
            auctioneer.Attach(new Bidder(auctioneer, "2. Gözlemeci"));
            auctioneer.Attach(new Bidder(auctioneer, "3. Gözlemeci"));

            Console.ReadKey();
        }
    }

    public interface IObserver
    {
        void Update();
    }
    public interface ISubject
    {
        void Attach(IObserver subscriber);
        void Detach(IObserver subscriber);
        void Notify();
    }

    public enum AuctionStatus
    {
        Increase,
        Sell
    }
    /// <summary>
    /// Gözlemci, açık arttırmaya katılan.
    /// </summary>
    public class Bidder : IObserver
    {
        Auctioneer _subject;
        string _name;

        public Bidder(Auctioneer subject, string name)
        {
            this._subject = subject;
            this._name = name;
        }
        public void Update()
        {
            AuctionStatus status = _subject.State;
            _subject.Detach(this);
        }
    }

    public class Auctioneer : ISubject
    {
        //açık arttırmayı yapan kişiyi gözlemleyenler
        private List<IObserver> _subscribers = null;

        public Auctioneer()
        {
            _subscribers = new List<IObserver>();
        }

        //aktif durum
        private AuctionStatus _activeStatus;        
        //durum değişikliği için
        public AuctionStatus State
        {
            get
            {
                return _activeStatus;
            }
            set
            {
                _activeStatus = value;
            }
        }
        public void Attach(IObserver subscriber)
        {
            foreach (var item in _subscribers)
            {
                if (_subscribers.Any(x => x.Equals(item) == false)) //aynı kullanıcıyı iki defa eklemeyelim diye
                {
                    _subscribers.Add(subscriber);
                    break;
                }
            }
        }

        public void Detach(IObserver subscriber)
        {
            foreach (var item in _subscribers)
            {
                if (_subscribers.Any(x => x.Equals(item)))
                {
                    _subscribers.Remove(subscriber);
                    break;
                }
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose();
        }

        public void Notify()
        {
            foreach (IObserver item in _subscribers)
            {
                item.Update();
            }
        }
    }
}
