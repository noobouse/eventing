using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace FNE.Eventing
{
    public class EventBroker : Hub
    {
        public Task AddHandler(string @event)
        {
            return Groups.Add(Context.ConnectionId, @event);
        }

        public Task RemoveHandler(string @event)
        {
            return Groups.Remove(Context.ConnectionId, @event);
        }

        public void Dispatch(string @event, dynamic message)
        {
            Clients.OthersInGroup(@event).Dispatch(@event, message);
        }
    }
}
