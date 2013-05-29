using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNE.Eventing.Configuration
{
    public class EventingServerConfigurationElement : ConfigurationElement
    {
        #region Url
        
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
    }
}
