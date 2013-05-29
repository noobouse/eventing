using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNE.Eventing.Configuration
{
    /// <summary>
    /// Represents configuration settings for the event broker in an eventing server project.
    /// </summary>
    public class EventBrokerConfigurationElement : ConfigurationElement
    {
        #region EnableCrossDomain

        /// <summary>
        /// Gets or sets a value indicating whether events can be dispatched cross domain.
        /// </summary>
        [ConfigurationProperty("enableCrossDomain", DefaultValue = true, IsRequired = false)]
        public bool EnableCrossDomain
        {
            get { return (bool)base["enableCrossDomain"]; }
            set
            {
                if (!base["enableCrossDomain"].Equals(value))
                    base["enableCrossDomain"] = value;
            }
        }

        #endregion

        #region EnableDetailedErrors

        /// <summary>
        /// Gets or sets a value indicating whether detailed errors should be included in event messages.
        /// </summary>
        [ConfigurationProperty("enableDetailedErrors", DefaultValue = false, IsRequired = false)]
        public bool EnableDetailedErrors
        {
            get { return (bool)base["enableDetailedErrors"]; }
            set
            {
                if (!base["enableDetailedErrors"].Equals(value))
                    base["enableDetailedErrors"] = value;
            }
        }

        #endregion

        #region EnableJavaScriptProxies

        /// <summary>
        /// Gets or sets a value indicating whether JavaScript proxies should be created for the event broker.
        /// </summary>
        [ConfigurationProperty("enableJavaScriptProxies", DefaultValue = true, IsRequired = false)]
        public bool EnableJavaScriptProxies
        {
            get { return (bool)base["enableJavaScriptProxies"]; }
            set
            {
                if (!base["enableJavaScriptProxies"].Equals(value))
                    base["enableJavaScriptProxies"] = value;
            }
        }

        #endregion
    }
}
