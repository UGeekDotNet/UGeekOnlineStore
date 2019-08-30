using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Infrastructre.RepositoryInterfaces;
using UGeekStore.DAL.Entities;

namespace UGeekStore.DAL.Repositories
{
    public class ShipperRepository : RepositoryBase<Shipper>, IShipperRepository
    {
        public ShipperRepository(StoreContext _context) : base(_context)
        {
        }

        public Task Example()
        {
            throw new NotImplementedException();
        }
    }
}
