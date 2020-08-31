using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloSingelton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo Singelton");

            //var logger = new Logger();


            for (int i = 0; i < 10; i++)
            {
                Task.Run(() => Logger.Instance.Log($"Test #{i}"));
            }

            //Logger.Instance.Log("Hallo Logger");
            //Logger.Instance.Log("Hallo Logger");
            //Logger.Instance.Log("Hallo Logger");

            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }
}
