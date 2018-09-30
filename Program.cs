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

            Bus bus1 = new Bus(71);
            Bus bus2 = new Bus(72);
            bus1.Drive();
            System.Threading.Thread.Sleep(300);
            bus2.Drive();
            Bus bus3 = new Bus(73);
            System.Threading.Thread.Sleep(500);
            bus3.Drive();

            Stock msft = new Stock("newstock");
            House mansion = new House("mansion");

            Display(msft);
            Display(mansion);

            Stack stack = new Stack();
            stack.Push("sausage");
            string s = (string)stack.Pop();   // Downcast, so explicit cast is needed

            Console.WriteLine(s);             // sausage

            Panda panda = new Panda { Name = "Bob" };
            Console.WriteLine(panda.ToString());

            Point point1 = new Point();
            Point point2 = new Point(1, 3);
        }

        public static void Display(Asset asset)
        {
            Console.WriteLine(asset.Name);
        }
    }

    public struct Point
    {
        int x, y;
        public Point(int x, int y) { this.x = x; this.y = y; }
    }
    public class Panda
    {
        public string Name;
        public override string ToString() => Name;
    }
    public class Stack
    {
        int Position;
        object[] data = new object[10];
        public void Push(object obj) { data[Position++] = obj; }
        public object Pop() { return data[--Position]; }

    }
    public class Asset
    {
        public string Name;
    }
    public class Stock : Asset
    {
        public Stock(string name)
        {
            Name = name;
        }
    }
    public class House : Asset
    {
        public House(string name)
        {
            Name = name;
        }

    }
    public class Bus
    {
        protected static readonly DateTime globalStartTime;
        protected int RouteNumber { get; set; }
        static Bus()
        {
            globalStartTime = DateTime.Now;
            Console.WriteLine("Global Start Time is assigned: {0}", globalStartTime);
        }

        public Bus(int routeNum)
        {
            RouteNumber = routeNum;
            Console.WriteLine("Bus #{0} is created", routeNum);

        }

        public void Drive()
        {
            TimeSpan elapsedTime = DateTime.Now - globalStartTime;
            Console.WriteLine("{0} is starting its route {1:N2} minutes after global start time {2}.",
                        this.RouteNumber,
                        elapsedTime.TotalMilliseconds,
                        globalStartTime.ToShortTimeString());
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
