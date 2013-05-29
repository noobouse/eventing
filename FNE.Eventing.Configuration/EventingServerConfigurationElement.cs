using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNE.Eventing.Configuration
{
    /// <summary>
    /// Represents configuration settings for the eventing server.
    /// </summary>
    public class EventingServerConfigurationElement : ConfigurationElement
    {
        #region Url
        
        /// <summary>
        /// Gets or sets the endpoint of the eventing server.
        /// </summary>
        [ConfigurationProperty("url", IsRequired = true)]
        public string Url
        {
            get { return (string)base["url"]; }
            set
            {
                if (!base["url"].Equals(value))
                    base["url"] = value;
            }
        }

        #endregion

        #region UseSignalR
        
        /// <summary>
        /// Gets or sets a value indicating whether SignalR should be used for communication.
        /// </summary>
        [ConfigurationProperty("useSignalR", DefaultValue = true, IsRequired = false)]
        public bool UseSignalR
        {
            get { return (bool)base["useSignalR"]; }
            set
            {
                if (!base["useSignalR"].Equals(value))
                    base["useSignalR"] = value;
            }
        }

        #endregion

        #region EventBroker

        /// <summary>
        /// Gets or sets the event broker configuration settings.
        /// </summary>
        [ConfigurationProperty("eventBroker", IsRequired = false)]
        public EventBrokerConfigurationElement EventBroker
        {
            get { return (EventBrokerConfigurationElement)base["eventBroker"]; }
            set
            {
                if (!base["eventBroker"].Equals(value))
                    base["eventBroker"] = value;
            }
        }

        #endregion
    }
}
