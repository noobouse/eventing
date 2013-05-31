using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNE.Eventing.Configuration
{
    /// <summary>
    /// Represents configuration settings for the custom eventing configuration section in both eventing 
    /// client and server applications.
    /// </summary>
    public class EventingConfigurationSection : ConfigurationSection
    {
        #region Server

        /// <summary>
        /// Gets or sets the server configuration.
        /// </summary>
        [ConfigurationProperty("server", IsRequired = false)]
        public EventingServerConfigurationElement Server
        {
            get { return (EventingServerConfigurationElement)base["server"]; }
            set
            {
                if (!base["server"].Equals(value))
                    base["server"] = value;
            }
        }

        #endregion

        #region Dispatcher

        /// <summary>
        /// Gets or sets the dispatcher configuration.
        /// </summary>
        [ConfigurationProperty("dispatcher", IsRequired = false)]
        public EventDispatcherConfigurationElement Dispatcher
        {
            get { return (EventDispatcherConfigurationElement)base["dispatcher"]; }
            set
            {
                if (!base["dispatcher"].Equals(value))
                    base["dispatcher"] = value;
            }
        }

        #endregion
    }
}
