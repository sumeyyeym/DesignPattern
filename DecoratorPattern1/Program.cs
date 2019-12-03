using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern1
{
    class Program
    {
        static void Main(string[] args)
        {
            FreshSalad sezarSalad = new FreshSalad("Maydanoz, pırasa, yeşil soğan, ıspanak", "Tulum, kaşar, parmesan", "Salça, ezme, nar ekşisi");
            sezarSalad.Display();

            Pasta pasta = new Pasta("Ölü pastası", "Nar ekşisi, çikolata sosu, turşu suyu, parmesan");
            pasta.Display();

            Available sezarSaladAvailable = new Available(sezarSalad, 3);
            Available pastaAvailable = new Available(pasta, 4);
            sezarSaladAvailable.OrderItem("Meryem");
            sezarSaladAvailable.OrderItem("Şeyma");
            sezarSaladAvailable.OrderItem("Sümeyye");
            pastaAvailable.OrderItem("Zehra");
            pastaAvailable.OrderItem("Meryem");
            pastaAvailable.OrderItem("Şeyma");
            pastaAvailable.OrderItem("Hayrunnisa");
            pastaAvailable.OrderItem("Sümeyye");
            sezarSaladAvailable.Display();
            pastaAvailable.Display();

            Console.ReadKey();
        }
    }

    public abstract class RestourantDish
    {
        public abstract void Display();
    }
    class FreshSalad : RestourantDish
    {
        private string _greens;
        private string _cheese;
        private string _dressing;

        public FreshSalad(string greens, string cheese, string dressing)
        {
            this._greens = greens;
            this._cheese = cheese;
            this._dressing = dressing;
        }
        public override void Display()
        {
            Console.WriteLine("\nFresh  : ");
            Console.WriteLine("Greens   : {0}", this._greens);
            Console.WriteLine("Cheese   : {0}", this._cheese);
            Console.WriteLine("Dressing : {0}", this._dressing);
        }
    }

    class Pasta : RestourantDish
    {
        private string _pastaType;
        private string _sauce;

        public Pasta(string pastaType, string sauce)
        {
            this._pastaType = pastaType;
            this._sauce = sauce;
        }
        public override void Display()
        {
            Console.WriteLine("\nClassic Pasta : ");
            Console.WriteLine("Pasta           : {0}", this._pastaType);
            Console.WriteLine("Sauce           : {0}", this._sauce);
        }                
    }
    public abstract class Decorator : RestourantDish
    {
        protected RestourantDish _dish;
        public Decorator(RestourantDish dish)
        {
            _dish = dish;
        }
        public override void Display()
        {
            _dish.Display();
        }
    }

    class Available : Decorator
    {
        public int NumAvailable { get; set; }
        protected List<string> customers = new List<string>();
        public Available(RestourantDish dish, int numAvailable) : base(dish) //eğer ctor'u olan bir classtan miras alınıyorsa mutlak surretle bu classta da ctor olmalı ve miras alınan clastaki ctorun parametresi ile aynı parametreleri almalı
        {
            this.NumAvailable = numAvailable;
        }

        public void OrderItem(string name)
        {
            if (NumAvailable > 0)
            {
                customers.Add(name);
                NumAvailable--;
            }
            else
            {
                Console.WriteLine("\nNot enough ingredients for " + name + "'s order!");
            }
        }
        public override void Display()
        {
            base.Display();
            foreach (string customer in customers)
            {
                Console.WriteLine("Order by " + customer);
            }
        }
    }
}
