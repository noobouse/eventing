using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace FNE.Eventing
{
    /// <summary>
    /// Adds client handlers for, removes client handlers from and dispatches named event messages.
    /// </summary>
    public class EventBroker : Hub
    {
        /// <summary>
        /// Adds a client handler for the named event.
        /// </summary>
        /// <param name="event">The name of the event.</param>
        /// <returns></returns>
        public Task AddHandler(string @event)
        {
            return Groups.Add(Context.ConnectionId, @event);
        }

        /// <summary>
        /// Removes a client handler from the named event.
        /// </summary>
        /// <param name="event">The name of the event.</param>
        /// <returns></returns>
        public Task RemoveHandler(string @event)
        {
            return Groups.Remove(Context.ConnectionId, @event);
        }

        /// <summary>
        /// Dispatches an event messages to all clients of the named event.
        /// </summary>
        /// <param name="event">The name of the event.</param>
        /// <param name="message">The event message.</param>
        public void Dispatch(string @event, dynamic message)
        {
            Clients.OthersInGroup(@event).Dispatch(@event, message);
        }
    }
}
