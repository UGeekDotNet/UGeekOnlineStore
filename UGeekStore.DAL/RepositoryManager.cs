using System;
using System.Threading.Tasks;
using UGeekStore.Core.Infrastructre.RepositoryAbstraction;
using UGeekStore.Core.Infrastructre.RepositoryInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace UGeekStore.DAL
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly StoreContext _context;

        public RepositoryManager(IServiceProvider serviceProvider, StoreContext context)
        {
            _serviceProvider = serviceProvider;
            _context = context;
        }

        private IShipperRepository _shippers;
        public IShipperRepository Shippers =>
            _shippers ?? (_shippers = _serviceProvider.GetService<IShipperRepository>());

        private ICategoryRepository _categories;
        public ICategoryRepository Categories =>
            _categories ?? (_categories = _serviceProvider.GetService<ICategoryRepository>());

        private ISupplierRepository _suppliers;
        public ISupplierRepository Suppliers =>
            _suppliers ?? (_suppliers = _serviceProvider.GetService<ISupplierRepository>());

        private IRoleRepository _roles;
        public IRoleRepository Roles =>
            _roles ?? (_roles = _serviceProvider.GetService<IRoleRepository>());

        private IProductRepository _products;
        public IProductRepository Products =>
            _products ?? (_products = _serviceProvider.GetService<IProductRepository>());

        private IUserRepository _users;
        public IUserRepository Users =>
            _users ?? (_users = _serviceProvider.GetService<IUserRepository>());

        private IMessageRepository _messages;
        public IMessageRepository Messages =>
            _messages ?? (_messages = _serviceProvider.GetService<IMessageRepository>());

        private IOrderRepository _orders;
        public IOrderRepository Orders =>
            _orders ?? (_orders = _serviceProvider.GetService<IOrderRepository>());

        private IOrderDetailRepository _orderdetails;
        public IOrderDetailRepository OrderDetails =>
            _orderdetails ?? (_orderdetails = _serviceProvider.GetService<IOrderDetailRepository>());

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}