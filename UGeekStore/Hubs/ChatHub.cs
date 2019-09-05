using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using UGeekStore.Core.Infrastructre.BLLInterfaces;
using UGeekStore.Core.Models;

namespace UGeekStore.Hubs
{

    public class ChatHub: Hub
    {
        public async Task SendMessage(string userName ,MessageModel message)
        {
           
            await  Clients.User(userName).SendAsync("reciverMessage", message);
        }
    }
}
