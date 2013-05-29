using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNE.Eventing.Logging;
using Microsoft.AspNet.SignalR;

namespace FNE.Eventing
{
    /// <summary>
    /// Adds client handlers for, removes client handlers from and dispatches named event messages.
    /// </summary>
    public class EventBroker : Hub
    {
        //
        // Fields

        private ILoggingProvider loggingProvider;

        //
        // Constructors

        #region EventBroker
        
        /// <summary>
        /// Initializes a new instance of the <see cref="EventBroker" class./>
        /// </summary>
        /// <param name="loggingProvider">The <see cref="ILoggingProvider"/> instance to use.</param>
        public EventBroker(ILoggingProvider loggingProvider = null)
            : base()
        {
            this.loggingProvider = loggingProvider;
        }

        #endregion

        //
        // Methods

        #region AddHandler
        
        /// <summary>
        /// Adds a client handler for the named event.
        /// </summary>
        /// <param name="event">The name of the event.</param>
        /// <returns></returns>
        public Task AddHandler(string @event)
        {
            return Groups.Add(Context.ConnectionId, @event);
        }

        #endregion

        #region RemoveHandler
        
        /// <summary>
        /// Removes a client handler from the named event.
        /// </summary>
        /// <param name="event">The name of the event.</param>
        /// <returns></returns>
        public Task RemoveHandler(string @event)
        {
            return Groups.Remove(Context.ConnectionId, @event);
        }

        #endregion

        #region Dispatch
        
        /// <summary>
        /// Dispatches an event messages to all clients of the named event.
        /// </summary>
        /// <param name="event">The name of the event.</param>
        /// <param name="message">The event message.</param>
        public void Dispatch(string @event, dynamic message)
        {
            Clients.OthersInGroup(@event).Dispatch(@event, message);
        }

        #endregion

        //
        // Hub Overrides

        #region OnConnected
        
        public override Task OnConnected()
        {
            try
            {
                return base.OnConnected();
            }

            finally
            {
                if (this.loggingProvider != null)
                    this.loggingProvider.LogInformation("Client {{{0}}} connected at {1}", Context.ConnectionId, DateTime.Now);
            }
        }

        #endregion

        #region OnDisconnected
        
        public override Task OnDisconnected()
        {
            try
            {
                return base.OnDisconnected();
            }

            finally
            {
                if (this.loggingProvider != null)
                    this.loggingProvider.LogInformation("Client {{{0}}} disconnected at {1}", Context.ConnectionId, DateTime.Now);
            }
        }

        #endregion

        #region OnReconnected
        
        public override Task OnReconnected()
        {
            try
            {
                return base.OnReconnected();
            }

            finally
            {
                if (this.loggingProvider != null)
                    this.loggingProvider.LogInformation("Client {{{0}}} reconnected at {1}", Context.ConnectionId, DateTime.Now);
            }
        }

        #endregion
    }
}
