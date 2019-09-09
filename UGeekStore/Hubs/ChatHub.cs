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
        IMessageOperation _messageOperation;
        public ChatHub(IMessageOperation messageOperation)
        {
            _messageOperation = messageOperation;
        }

        public async Task SendMessage(string userId ,string message)
        {
            if(string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(Context.User.Identity.Name))
            {
                throw new Exception("UserId is empty");
            }

            if (int.TryParse(userId, out int receiverId) && int.TryParse(Context.User.Identity.Name, out int senderId))
            {
                await Clients.User(userId).SendAsync("receiveMessage", arg1: message);
                var messageEntity = new MessageModel
                {
                    Message = message,
                    ReciverID = receiverId,
                    SenderID = senderId
                };
                await _messageOperation.AddMessage(messageEntity);
            }
        }
    }
}
