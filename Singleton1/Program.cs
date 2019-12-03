using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton1
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = SingletonClass1.Singleton; //bu classtan tek bir nesne oluşturduk. bundan ikinci bir tane kullanamayız. o sebetle her şeyi sabit kalır
            int sonuç = s1.Hesapla(12, 12);
            Console.WriteLine(sonuç);

            int s2 = SingletonClass1.SingletonInstance().Hesapla(10, 10);
            Console.WriteLine(s2);

            Console.ReadKey();
        }
    }
}
