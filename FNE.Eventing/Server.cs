using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;

namespace FNE.Eventing
{
    /// <summary>
    /// Manages the lifetime of the <see cref="EventBroker"/> service.
    /// </summary>
    public class Server
    {
        //
        // Fields

        private static Configuration.EventingConfigurationSection Configuration;

        //
        // Constructors

        static Server()
        {
            Configuration = ConfigurationManager.GetSection("eventing") as Configuration.EventingConfigurationSection;
        }

        /// <summary>
        /// Starts the server and the <see cref="EventBroker"/> service.
        /// </summary>
        /// <param name="url">The endpoint of the service. If a value is not provided, it will be read from a configuration file.</param>
        /// <returns></returns>
        public static IDisposable Start(string url = "")
        {
            return WebApplication.Start<Configurator>(Configuration.Server.Url ?? url);
        }

        //
        // Nested Types

        private class Configurator
        {
            public void Configuration(IAppBuilder builder)
            {
                // TODO: load hub settings from configuration

                builder.MapHubs(new HubConfiguration
                {
                    EnableCrossDomain = Server.Configuration.Server.EventBroker.EnableCrossDomain,
                    EnableDetailedErrors = Server.Configuration.Server.EventBroker.EnableDetailedErrors,
                    EnableJavaScriptProxies = Server.Configuration.Server.EventBroker.EnableJavaScriptProxies
                });
            }
        }
    }
}
