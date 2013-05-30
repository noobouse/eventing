using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventing = FNE.Eventing;
using Autofac;
using Autofac.Integration.SignalR;

namespace FNE.Eventing.Samples.ConsoleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            OnStart();

            using (Eventing.Server.Start(@"http://localhost:8088"))
            {
                Console.WriteLine("EventBroker server started...");
                Console.ReadLine();
            }
        }

        private static void OnStart()
        {
            var builder = new Autofac.ContainerBuilder();

            builder.RegisterHubs(System.Reflection.Assembly.GetAssembly(typeof(FNE.Eventing.EventBroker)));
            builder.RegisterType<NLogLoggingProvider>().AsImplementedInterfaces().InstancePerDependency();

            Microsoft.AspNet.SignalR.GlobalHost.DependencyResolver = new Autofac.Integration.SignalR.AutofacDependencyResolver(builder.Build());
        }
    }
}
