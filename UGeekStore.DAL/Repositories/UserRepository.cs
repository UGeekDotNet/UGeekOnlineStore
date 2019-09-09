using System.Threading.Tasks;
using UGeekStore.Core.Entities;
using UGeekStore.Core.Infrastructre.RepositoryInterfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UGeekStore.DAL.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(StoreContext _context) : base(_context)
        {

        }

        public async Task GetUsersSupplierByCity()
        {
            var result = await ((from user in Context.Users
                                 select new { user.City, user.Country })
                         .Union(from supplier in Context.Suppliers
                                select new { supplier.City, supplier.Country })).ToListAsync();
        }
    }
}
