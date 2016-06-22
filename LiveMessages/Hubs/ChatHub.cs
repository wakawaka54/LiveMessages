using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading;

namespace LiveMessages.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message, int messageID)
        {
            Clients.Caller.confirmDelivery(messageID);

            //Call the addNewMessageToPage method to update clients
            Clients.All.addNewMessageToPage("ADMIN", "I RECEIVED YOUR MESSAGE");
            Clients.All.addAdminMessage(Context.ConnectionId, name, message);
        }

        public void SendToUser(string id, string message)
        {
            Clients.User(id).addNewMessageToPage("ADMIN", message);
        }
    }
}