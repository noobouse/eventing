using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNE.Eventing.Configuration
{
    /// <summary>
    /// Represents configuration settings for the client <see cref="IDispatcher"/>.
    /// </summary>
    public class EventDispatcherConfigurationElement : ConfigurationElement
    {
        #region Url

        /// <summary>
        /// Gets or sets the url the <see cref="IDispatcher"/> connects to for cross-domain eventing.
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
    }
}
