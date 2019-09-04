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

        private ICategoryRepository _category;
        public ICategoryRepository Category =>
            _category ?? (_category = _serviceProvider.GetService<ICategoryRepository>());

        private IMessageRepository _message;
        public IMessageRepository Message =>
            _message ?? (_message = _serviceProvider.GetService<IMessageRepository>());

        private IOrderDetailRepository _orderDetail;
        public IOrderDetailRepository OrderDetail =>
            _orderDetail ?? (_orderDetail = _serviceProvider.GetService<IOrderDetailRepository>());

        private IOrderRepository _order;
        public IOrderRepository Order =>
             _order ?? (_order = _serviceProvider.GetService<IOrderRepository>());

       private IProductRepository _product;
        public IProductRepository Product =>
            _product ?? (_product = _serviceProvider.GetService<IProductRepository>());

       private IRoleRepository _role;
        public IRoleRepository Role =>
            _role ?? (_role = _serviceProvider.GetService<IRoleRepository>());

        private ISupplierRepository _supplier;
        public ISupplierRepository Supplie =>
            _supplier ?? (_supplier = _serviceProvider.GetService<ISupplierRepository>());


        private IUserRepository _user;
        public IUserRepository User =>
            _user ?? (_user = _serviceProvider.GetService<IUserRepository>());

        

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