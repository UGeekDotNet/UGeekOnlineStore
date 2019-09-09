using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Entities;
using UGeekStore.Core.Infrastructre.RepositoryAbstraction;

namespace UGeekStore.Core.Infrastructre.RepositoryInterfaces
{
   public interface IUserRepository : IRepositoryBase<User>
    {
        Task GetUsersSupplierByCity();
    }
}
