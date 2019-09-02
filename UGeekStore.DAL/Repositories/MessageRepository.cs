using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.RepasitoryInterfaces;
using UGeekStore.DAL.Entities;

namespace UGeekStore.DAL.Repositories
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(StoreContext _context) : base(_context)
        {
        }
    }
}
