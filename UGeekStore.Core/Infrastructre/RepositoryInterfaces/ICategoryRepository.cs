using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Entities;
using UGeekStore.Core.Infrastructre.RepositoryAbstraction;
using UGeekStore.Core.ViewModels;

namespace UGeekStore.Core.Infrastructre.RepositoryInterfaces
{
   public interface ICategoryRepository:IRepositoryBase<Category>
    {
        Task<List<SalesCategoriesModel>> GetCategorySalesForAllTime(IProductRepository repo);
    }
}
