using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.RepasitoryInterfaces;
using UGeekStore.DAL.Entities;

namespace UGeekStore.DAL.Repositories
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository 
    {
        public OrderDetailRepository(StoreContext _context) : base(_context)
        {
        }
    }
}
