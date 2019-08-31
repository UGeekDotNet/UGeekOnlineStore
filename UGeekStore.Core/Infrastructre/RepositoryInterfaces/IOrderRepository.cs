using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Entities;
using UGeekStore.Core.Infrastructre.RepositoryAbstraction;

namespace UGeekStore.Core.Infrastructre.RepositoryInterfaces
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
    }
}
