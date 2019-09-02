using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.RepositoryAbstraction;
using UGeekStore.DAL.Entities;

namespace UGeekStore.Core.Infrastructre.RepasitoryInterfaces
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
    }
}
