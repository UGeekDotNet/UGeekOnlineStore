using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Infrastructre.RepositoryAbstraction;
using UGeekStore.DAL.Entities;

namespace UGeekStore.Core.Infrastructre.RepositoryInterfaces
{
    public interface IShipperRepository : IRepositoryBase<Shipper>
    {
        Task Example();
    }
}
