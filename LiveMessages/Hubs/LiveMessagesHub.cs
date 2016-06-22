using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace LiveMessages.Hubs
{
    public class LiveMessagesHub : Hub
    {
        [Authorize(Roles = "Admin")]
        public void AdminLogin(string name)
        {

        }

        public void SendToAdmins(string message)
        {
            //Receive message from client page
            
        }

        [Authorize(Roles = "Admin")]
        public void SendToClient(string id, string name, string message)
        {
            //Post message to client page using LiveMessagesJS
            Clients.User(id).PostMessage(name, message);
        }
    }
}