using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton1
{
    public class SingletonClass1
    {
        private SingletonClass1() //ctor'u private yaparak bu sınıfın dışından instance alınmasını engelledik. RAM'e her seferinde tekrar tekrar yeni nesne çıkarmaktansa tek bir nesne oluşturarak her değişkeni vs. bu tek nesneye bağlıyor. Her seferinde yeni nesnelerle rami şişirmektense tek bir nesne ile tüm erişimi sağlamak
        {
        }

        private static SingletonClass1 _singleton = new SingletonClass1(); //burada hata vermez çünkü biz yukarıdaki classı dışarıya kapadık, burada kullanmamızda herhangi bir sıkıntı yok

        public static SingletonClass1 Singleton
        {
            get
            {
                return _singleton;
            }
        }

        public static SingletonClass1 SingletonInstance()
        {
            return _singleton;
        }

        public int Hesapla(int s1, int s2)
        {
            return s1 + s2;
        }
    }
}
