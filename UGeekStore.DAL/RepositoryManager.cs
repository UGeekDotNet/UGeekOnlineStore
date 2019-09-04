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
        private IProductRepository _products;
        private IOrderRepository _orders;
        private IOrderDetailRepository _orderDetails;
        private IMessageRepository _messages;
        private IRoleRepository _roles;
        private ICategoryRepository _categories;
        private ISupplierRepository _suppliers;
        private IUserRepository _users;

        public IShipperRepository Shippers =>
            _shippers ?? (_shippers = _serviceProvider.GetService<IShipperRepository>());
        public ISupplierRepository Suppliers =>
            _suppliers ?? (_suppliers = _serviceProvider.GetService<ISupplierRepository>());
        public IProductRepository Products =>
            _products ?? (_products = _serviceProvider.GetService<IProductRepository>());
        public IOrderRepository Orders =>
            _orders ?? (_orders = _serviceProvider.GetService<IOrderRepository>());
        public IOrderDetailRepository OrderDetails =>
            _orderDetails ?? (_orderDetails = _serviceProvider.GetService<IOrderDetailRepository>());
        public IUserRepository Users =>
            _users ?? (_users = _serviceProvider.GetService<IUserRepository>());
        public IRoleRepository Roles =>
            _roles ?? (_roles = _serviceProvider.GetService<IRoleRepository>());
        public ICategoryRepository Categories =>
            _categories ?? (_categories = _serviceProvider.GetService<ICategoryRepository>());
        public IMessageRepository Messages =>
            _messages ?? (_messages = _serviceProvider.GetService<IMessageRepository>());

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