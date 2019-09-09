using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Entities;
using UGeekStore.Core.Infrastructre.RepositoryInterfaces;
using UGeekStore.Core.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UGeekStore.DAL.Repositories
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(StoreContext _context) : base(_context)
        {

        }
        
    }
}
