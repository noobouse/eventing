using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNE.Eventing.Configuration
{
    public class EventBrokerConfigurationElement : ConfigurationElement
    {
        #region EnableCrossDomain

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
