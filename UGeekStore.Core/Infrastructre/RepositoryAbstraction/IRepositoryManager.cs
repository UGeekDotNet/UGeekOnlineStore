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
        ISupplierRepository Suppliers { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        IOrderDetailRepository OrderDetails { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        ICategoryRepository Categories { get; }
        IMessageRepository Messages { get; }

        Task<int> CompleteAsync();
        int Complete();
    }
}
