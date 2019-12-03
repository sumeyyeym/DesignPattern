using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton1
{
    public class SingletonClass2
    {
        private SingletonClass2() { }

        private static SingletonClass2 _singleton;        
        public static SingletonClass2 Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new SingletonClass2(); //daha önce biri ram üzerine bu sınıfı çıkarmadıysa yeni bir tane oluşturuyoruz
                }
                return _singleton; //kullanıcıya elimizdeki var olan neseyi teslim ediyoruz
            }
        }
    }
}
