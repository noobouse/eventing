using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventing = FNE.Eventing;

namespace FNE.Eventing.Samples.ConsoleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Eventing.Server.Start(@"http://localhost:8088"))
            {
                Console.WriteLine("EventBroker server started...");
                Console.ReadLine();
            }
        }
    }
}
