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
        ICategoryRepository Categories { get; }
        ISupplierRepository Suppliers { get; }
        IRoleRepository Roles { get; }
        IProductRepository Products { get; }
        IUserRepository Users { get; }
        IMessageRepository Messages { get; }
        IOrderRepository Orders { get; }
        IOrderDetailRepository OrderDetails { get; }

        Task<int> CompleteAsync();
        int Complete();
    }
}
