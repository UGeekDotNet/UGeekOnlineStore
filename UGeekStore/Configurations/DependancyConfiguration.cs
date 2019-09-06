using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UGeekStore.BLL.Operations;
using UGeekStore.Core.Infrastructre.BLLInterfaces;
using UGeekStore.Core.Infrastructre.RepositoryAbstraction;
using UGeekStore.Core.Infrastructre.RepositoryInterfaces;
using UGeekStore.DAL;
using UGeekStore.DAL.Repositories;

namespace UGeekStore.Configurations
{
    public static class DependancyConfiguration
    {
        public static void AddDALServices(this IServiceCollection services)
        {
            foreach (var entry in Repositories)
            {
                services.Add(new ServiceDescriptor(entry.Key, entry.Value, ServiceLifetime.Transient));
            }
        }

        public static void AddBLLServices(this IServiceCollection services)
        {
            foreach (var entry in Operations)
            {
                services.Add(new ServiceDescriptor(entry.Key, entry.Value, ServiceLifetime.Transient));
            }
        }
        private static readonly Dictionary<Type, Type> Operations = new Dictionary<Type, Type>
        {
            {typeof(ICategoryOperation),typeof(CategoryOperation) },
            {typeof(IShipperOperation),typeof(ShipperOperation) },
            {typeof(ISupplierOperation),typeof(SupplierOperation) },
            {typeof(IUserOperation),typeof(UserOperation) },
            {typeof(IMessageOperation),typeof(MessageOperation) },
            {typeof(IOrderDetailOperation),typeof(OrderDetailOperation) },
            {typeof(IOrderOperation),typeof(OrderOperation) },
            {typeof(IProductOperation),typeof(ProductOperation) },
            {typeof(IRoleOperation),typeof(RoleOperation) }
        };

        private static readonly Dictionary<Type, Type> Repositories = new Dictionary<Type, Type>
        {
            {typeof(IRepositoryManager),typeof(RepositoryManager) },
            {typeof(ICategoryRepository),typeof(CategoryRepository) },
            {typeof(IShipperRepository),typeof(ShipperRepository) },
            {typeof(ISupplierRepository),typeof(SupplierRepository) },
            {typeof(IUserRepository),typeof(UserRepository) },
            {typeof(IMessageRepository),typeof(MessageRepository) },
            {typeof(IOrderDetailRepository),typeof(OrderDetailRepository) },
            {typeof(IOrderRepository),typeof(OrderRepository) },
            {typeof(IProductRepository),typeof(ProductRepository) },
            {typeof(IRoleRepository),typeof(RoleRepository) }
        };
    }
}
