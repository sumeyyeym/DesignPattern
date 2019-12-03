using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern1
{
    class Program
    {
        //proxy'nin amacı: bir nesneye erişirken güvenlikli erişimi sağlamak 

        static void Main(string[] args)
        {
            string username = "", password = "";
            double total = 0;
            bool loginresult = false;

            do
            {
                if (!loginresult)
                {
                    Console.WriteLine("Lütfen kullanıcı adınızı giriniz:");
                    username = Console.ReadLine();
                  
                    Console.WriteLine("Lütfen şifrenizi giriniz:");
                    password = Console.ReadLine();
                }
                

                Console.WriteLine("Lütfen ödenecek tutarı giriniz:");
                total = Convert.ToDouble(Console.ReadLine());

                IBanka banka = new ProxyBanka(username, password);
                loginresult = banka.LoginStatus;
                bool result = banka.OdemeYap(total);
               
                Console.WriteLine("********************************************");

                if (result)
                {
                    break;
                }
            } while (true);

            Console.ReadKey();
        }
    }

    public interface IBanka
    {
        bool OdemeYap(double tutar);
        bool LoginStatus { get; set; }
    }
    public class Banka : IBanka
    {
        public bool LoginStatus { get; set; }

        public bool OdemeYap(double tutar)
        {
            if (tutar < 100)
            {
                Console.WriteLine($"Ödeyeceğiniz tutar 100 TL'den az olamaz => {100 - tutar}");
            }
            else if (tutar > 100)
            {
                Console.WriteLine($"Ödeyeceğiniz tutar 100 TL'den fazla olamaz => {tutar - 100}");
            }
            else
            {
                Console.WriteLine($"Ödeme başarıyla gerçekleştirildi => {tutar}");
                return true;
            }
            return false;
        }
    }

    public class ProxyBanka : IBanka
    {
        Banka _banka;
        bool _login;
        string _username, _password;
        
        public bool LoginStatus { get => _login; set { } }
        public ProxyBanka(string username, string password)
        {
            this._username = username;
            this._password = password;
        }

        bool Login()
        {
            if (_username.Equals("bilgeadam") && _password.Equals("12345"))
            {
                _banka = new Banka();
                _login = true;
                
                Console.WriteLine("Hesaba giriş yapıldı");
            }
            else
            {
                Console.WriteLine("Lütfen kullanıcı bilgilerini düzgün girin");
                _login = false;
            }
            return _login;
        }

        public bool OdemeYap(double tutar)
        {
            bool result = Login();
            if (!result)
            {
                Console.WriteLine("Hesaba giriş yapılmadığından dolayı işleme devam edemiyoruz.");
            }
            
            return _banka.OdemeYap(tutar);
        }
    }
}
