using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Entities;
using UGeekStore.Core.Infrastructre.RepositoryInterfaces;

namespace UGeekStore.DAL.Repositories
{
  public  class MessageRepository : RepositoryBase<Message>,IMessageRepository
    {
        public MessageRepository(StoreContext _context) : base(_context)
        {

        }
    }
}
