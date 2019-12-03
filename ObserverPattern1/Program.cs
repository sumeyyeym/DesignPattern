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
        public void Update()
        {
            throw new NotImplementedException();
        }
    }

    public class Auctioneer : ISubject
    {
        //açık arttırmayı yapan kişiyi gözlemleyenler
        private List<IObserver> _subscribers = null;

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
            throw new NotImplementedException();
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}
