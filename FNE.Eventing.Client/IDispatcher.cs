using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNE.Eventing.Client
{
    /// <summary>
    /// Provides methods to add handlers to, remove handlers from and trigger dispatched events.
    /// </summary>
    public interface IDispatcher
    {
        /// <summary>
        /// Adds a handler for the named event.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the event message.</typeparam>
        /// <param name="event">The name of the event.</param>
        /// <param name="handler">The event handler delegate.</param>
        void On<T>(string @event, Action<T> handler);

        /// <summary>
        /// Removes the handler from the named event.
        /// </summary>
        /// <param name="event">The name of the event.</param>
        void Off(string @event);

        /// <summary>
        /// Triggers the named event and dispatches the provided method.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the event message.</typeparam>
        /// <param name="event">The name of the event.</param>
        /// <param name="message">The event message.</param>
        void Trigger<T>(string @event, T message);
    }
}
