using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNE.Eventing.Client
{
    /// <summary>
    /// Manages the adding handlers to, removing handlers from and triggering dispatched events.
    /// </summary>
    public abstract class Dispatcher : IDispatcher
    {
        //
        // Fields

        private static IDispatcher current;

        //
        // Constructors

        #region Dispatcher

        static Dispatcher()
        {
            var configuration = System.Configuration.ConfigurationManager.GetSection("eventing") as Configuration.EventingConfigurationSection;

            if (configuration == null)
                throw new InvalidOperationException("The 'eventing' configuration section is missing or cannot be loaded.");

            current = new SignalRDispatcher(configuration.Dispatcher);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Dispatcher"/> class.
        /// </summary>
        protected Dispatcher()
            : base()
        {
        }

        #endregion

        //
        // Static Accessor

        #region Current

        /// <summary>
        /// Gets the current <see cref="IDispatcher"/>.
        /// </summary>
        public static IDispatcher Current
        {
            get { return current; }
        }

        #endregion

        //
        // IDispatcher Methods

        #region On
        
        /// <summary>
        /// When overridden in a derived class, adds a handler for the named event.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the event message.</typeparam>
        /// <param name="event">The name of the event.</param>
        /// <param name="handler">The event handler delegate.</param>
        public abstract void On<T>(string @event, Action<T> handler);

        #endregion

        #region Off
        
        /// <summary>
        /// When overridden in a derived class, removes the handler from the named event.
        /// </summary>
        /// <param name="event">The name of the event.</param>
        public abstract void Off(string @event);

        #endregion

        #region Trigger
        
        /// <summary>
        /// When overridden in a derived class, triggers the named event and dispatches the provided method.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the event message.</typeparam>
        /// <param name="event">The name of the event.</param>
        /// <param name="message">The event message.</param>
        public abstract void Trigger<T>(string @event, T message);

        #endregion
    }
}
