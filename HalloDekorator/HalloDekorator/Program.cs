using Microsoft.VisualBasic.CompilerServices;
using System;

namespace HalloDekorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Dekorator!");

            var pizza1 = new Käse(new Pizza());
            Console.WriteLine($"P1: {pizza1.Name} {pizza1.Preis}");

            var pizza2 = new Käse(new Salami(new Käse(new Käse(new Pizza()))));
            Console.WriteLine($"P2: {pizza2.Name} {pizza2.Preis}");

            var brot = new Käse(new Salami(new Brot()));
            Console.WriteLine($"Brot: {brot.Name} {brot.Preis}");


            Console.ReadKey();
        }
    }

    public interface ICompo
    {
        public string Name { get; }
        public decimal Preis { get; }

        public int KCal { get; }
    }

    class Pizza : ICompo
    {
        public string Name => "Pizza";

        public decimal Preis => 6.2m;

        public int KCal => 230;
    }

    class Brot : ICompo
    {
        public string Name => "Brot";

        public decimal Preis => 2.6m;

        public int KCal => 80;
    }


    abstract class Deco : ICompo
    {
        protected readonly ICompo parent;

        public Deco(ICompo parent)
        {
            this.parent = parent;
        }

        public abstract string Name { get; }

        public abstract decimal Preis { get; }

        public int KCal => 100;
    }

    class Käse : Deco
    {
        public Käse(ICompo parent) : base(parent)
        { }

        public override string Name => parent.Name + " Käse";

        public override decimal Preis => parent.Preis + 1.5m;
    }

    class Salami : Deco
    {
        public Salami(ICompo parent) : base(parent)
        { }

        public override string Name => parent.Name + " Salami";

        public override decimal Preis => parent.Preis + 2.4m;
    }
}
