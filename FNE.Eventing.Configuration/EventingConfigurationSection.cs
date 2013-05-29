using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNE.Eventing.Configuration
{
    public class EventingConfigurationSection : ConfigurationSection
    {
        #region Server

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
