using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Starts the server and the <see cref="EventBroker"/> service.
        /// </summary>
        /// <param name="url">The endpoint of the service. If a value is not provided, it will be read from a configuration file.</param>
        /// <returns></returns>
        public static IDisposable Start(string url = "")
        {
            // TODO: load server settings from configuration

            return WebApplication.Start<Server>(url);
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
                    EnableCrossDomain = true,
                    EnableDetailedErrors = true,
                    EnableJavaScriptProxies = true
                });
            }
        }
    }
}
