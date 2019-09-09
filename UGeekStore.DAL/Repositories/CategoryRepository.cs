using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Entities;
using UGeekStore.Core.Infrastructre.RepositoryInterfaces;
using System.Linq;
using UGeekStore.Core.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace UGeekStore.DAL.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        
        public CategoryRepository(StoreContext _context) : base(_context)
        {

        }
      public async Task<List<SalesCategoriesModel>> GetCategorySalesForAllTime(IProductRepository repo)
        {
            var products =await repo.ProductSalesForAllTime();
            var result = (from categorySales in products
                          group categorySales by categorySales.CategoryName into Categoryes
                          select new SalesCategoriesModel
                          {
                              CategoryName = Categoryes.FirstOrDefault().CategoryName
                             ,
                              SalesCategories = Categoryes.Sum(x => x.Sales)
                          }).ToList();

            return result; 


        }

        
    }
}
