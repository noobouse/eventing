using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client.Hubs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FNE.Eventing.Client
{
    internal class SignalRDispatcher : Dispatcher
    {
        //
        // Fields

        private HubConnection connection;
        private IHubProxy proxy;
        private ConcurrentDictionary<string, DelegateEventHandler> handlers;

        //
        // Constructors

        internal SignalRDispatcher(Configuration.EventDispatcherConfigurationElement configuration)
            : this(configuration.Url)
        {
        }

        internal SignalRDispatcher(string url)
            : base()
        {
            connection = new HubConnection(url);
            proxy = connection.CreateHubProxy("eventBroker");
            handlers = new ConcurrentDictionary<string, DelegateEventHandler>();

            proxy.On<string, JContainer>("dispatch", DelegateDispatchedEvent);

            connection.Start().Wait();
        }

        //
        // Event Handler

        private void DelegateDispatchedEvent(string @event, JContainer message)
        {
            DelegateEventHandler handler;

            if (this.handlers.TryGetValue(@event, out handler))
                handler.Invoke(message);
        }
        
        //
        // Dispatcher Members

        public override void On<T>(string @event, Action<T> handler)
        {
            this.proxy.Invoke("addHandler", @event)
                      .ContinueWith(c =>
                          {
                              if (c.IsCompleted)
                              {
                                  this.handlers.AddOrUpdate(
                                      @event,
                                      DelegateEventHandler.Create(handler, typeof(T), proxy.JsonSerializer),
                                      (k, v) => DelegateEventHandler.Update(v, handler, typeof(T))
                                  );
                              }
                          });
        }

        public override void Off(string @event)
        {
            DelegateEventHandler handler;
            this.handlers.TryRemove(@event, out handler);
        }

        public override void Trigger<T>(string @event, T message)
        {
            proxy.Invoke<T>("dispatch", @event, message).Wait();
        }

        //
        // Nested Type

        private class DelegateEventHandler
        {
            //
            // Fields

            private Type objectType;
            private Delegate action;
            private JsonSerializer serializer;

            //
            // Methods

            public void Invoke(JContainer message)
            {
                action.DynamicInvoke(message.ToObject(objectType));
            }

            //
            // Static Methods

            public static DelegateEventHandler Create(Delegate action, Type objectType, JsonSerializer serializer)
            {
                return new DelegateEventHandler { action = action, objectType = objectType, serializer = serializer };
            }

            public static DelegateEventHandler Update(DelegateEventHandler handler, Delegate action, Type objectType)
            {
                handler.action = action;
                handler.objectType = objectType;

                return handler;
            }
        }
    }
}
