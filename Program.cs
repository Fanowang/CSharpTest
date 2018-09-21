using System;

namespace CSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Wine wine = new Wine(12.2m, 15);

            Console.WriteLine(string.Format("Price is {0}, year is {1}, indexer is {2}", wine.Price, wine.Year, wine.Indexer));

            Bottle.Number = 1;
            Console.WriteLine(string.Format("Number is {0}", Bottle.Number));
            Bottle.Create();
            Console.WriteLine(string.Format("Number is {0}", Bottle.Number));

            //Bunny b1 = new Bunny { Name = "Bo", LikeCarrots = true, LikeHumans = false };
            //Bunny b2 = new Bunny("Bo") { LikeCarrots = true, LikeHumans = false };


            Bunny b2 = new Bunny("bb", true, true);
            //b2.Name = "tt";
            //Console.WriteLine(string.Format("Bunny name is {0}, LikeCarrots is {1}, LikeHuman is {2}", b1.Name, b1.LikeCarrots, b1.LikeHumans));
            Console.WriteLine(string.Format("Bunny name is {0}, LikeCarrots is {1}, LikeHuman is {2}", b2.Name, b2.LikeCarrots, b2.LikeHumans));
        }
    }

    public class Bunny
    {
        public readonly string Name;
        public readonly bool LikeCarrots;
        public readonly bool LikeHumans;

        public Bunny() { }
        public Bunny(string n) { Name = n; }

        public Bunny(string name, bool likeCarrots = false, bool likeHumans = false)
        {
            Name = name;
            LikeCarrots = likeCarrots;
            LikeHumans = likeHumans;
        }

    }

    public class Bottle
    {
        public static int Number;
        Bottle()
        {

        }

        public static void Create()
        {
            Number += 1;
        }

    }
    public class Wine
    {
        public decimal Price;
        public int Year;
        public decimal Indexer;
        static decimal Index(decimal price, int year)
        {
            return price * year;
        }
        public Wine(decimal indexer) { Indexer = indexer; }
        public Wine(decimal price, int year) : this(Index(price, year))
        {
            Year = year;
            Price = price;
        }


    }
}
