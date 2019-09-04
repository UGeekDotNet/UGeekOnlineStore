using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Models;

namespace UGeekStore.Core.Infrastructre.BLLInterfaces
{
    public interface IMessageOperation
    {
        Task<MessageModel> GetMessage(long id);
        Task AddMessage(MessageModel message);
        Task UpdateMessage(MessageModel messageModel);
        Task DeleteMessage(long id);
    }
}
