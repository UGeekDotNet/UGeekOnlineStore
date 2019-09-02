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