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
        [ConfigurationProperty("server", IsRequired = true)]
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
    }
}
