using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Entities;
using UGeekStore.Core.Infrastructre.RepositoryInterfaces;

namespace UGeekStore.DAL.Repositories
{
   public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(StoreContext _context)  : base(_context)
        {

        }
    }
}
