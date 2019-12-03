using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IKonu subject = new Proxy();
            Console.WriteLine(subject.Talep());

            KorumaliProxy subjectProxy = new KorumaliProxy();
            Console.WriteLine(subjectProxy.Talep());
            Console.WriteLine((subjectProxy as KorumaliProxy).KimlikDogrulama("123"));
            Console.WriteLine((subjectProxy as KorumaliProxy).KimlikDogrulama("bilgeadam"));
            Console.WriteLine(subjectProxy.Talep());

            Console.ReadKey();
        }
    }

    //Nesneler ve proxy'ler için birbilerinin yerine kullanılmalarını sağlayan ortak ara birim
    public interface IKonu
    {
        string Talep();
    }

    public class Konu
    {
        public string Talep()
        {
            return "Subject Talebi";
        }
    }

    public class Proxy : IKonu
    {
        Konu _konu;
        public string Talep()
        {
            if (_konu == null)
            {
                Console.WriteLine("Subject artık aktif değil");
                _konu = new Konu();
            }
            Console.WriteLine("Subject aktif");
            return "Proxy : Çağırılıyor..." + _konu.Talep();
        }
    }

    public class KorumaliProxy : IKonu
    {
        Konu _konu;
        string pass = "bilgeadam";

        public string KimlikDogrulama(string gelenSifre)
        {
            if (gelenSifre != pass)
            {
                return "Protected Proxy : Erişim yok";
            }
            else
            {
                _konu = new Konu();
                return "Protected Proxy : Kimlik doğrulandı";
            }
        }
        public string Talep()
        {
            if (_konu == null)
            {
                return "Protected Proxy : Önce kimlik doğrulaması gerekli.";
            }
            else
            {
                return "Protected Proxy çalışıyor" + _konu.Talep();
            }
        }
    }
}
