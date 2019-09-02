using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.RepasitoryInterfaces;
using UGeekStore.DAL.Entities;

namespace UGeekStore.DAL.Repositories
{
    public class RoleRepository : RepositoryBase<Role> , IRoleRepository
    {
        public RoleRepository(StoreContext _context) : base(_context)
        {
        }
    }
}
