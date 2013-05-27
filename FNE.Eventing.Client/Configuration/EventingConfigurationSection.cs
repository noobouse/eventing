using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNE.Eventing.Client.Configuration
{
    public class EventingConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("server", IsRequired = true)]
        public EventingServerConfigurationElement Server { get; set; }
    }
}
