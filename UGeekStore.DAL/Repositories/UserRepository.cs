using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Entities;
using UGeekStore.Core.Infrastructre.RepositoryAbstraction;

namespace UGeekStore.DAL.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(StoreContext _context) : base(_context)
        {
           
        }
    }
}
