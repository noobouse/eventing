using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNE.Eventing.Samples.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var dispatcher = FNE.Eventing.Client.Dispatcher.Current;

            dispatcher.On<string>("dispatcher:test", c => Console.WriteLine(c));

            Console.WriteLine("Client started...");
            Console.ReadLine();
        }
    }
}
