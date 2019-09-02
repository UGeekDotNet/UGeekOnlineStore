using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Entities;
using UGeekStore.Core.Infrastructre.RepositoryInterfaces;

namespace UGeekStore.DAL.Repositories
{
    public class OrderDetalisRepository : RepositoryBase<OrderDetail>, IOrderDetalisRepository
    {
        public OrderDetalisRepository(StoreContext _context):base(_context)
        {

        }
    }
}
