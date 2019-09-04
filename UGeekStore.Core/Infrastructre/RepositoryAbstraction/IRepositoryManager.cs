using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Infrastructre.RepositoryInterfaces;

namespace UGeekStore.Core.Infrastructre.RepositoryAbstraction
{
    public interface IRepositoryManager
    {
        IShipperRepository Shippers { get; }
        ICategoryRepository Category { get; }
        IOrderDetailRepository OrderDetail { get; }
        IMessageRepository Message { get; }
        IOrderRepository Order { get; }
        IProductRepository Product { get; }
        IRoleRepository Role { get; }
        ISupplierRepository Supplie { get; }
        IUserRepository User { get; }


        Task<int> CompleteAsync();
        int Complete();
    }
}
