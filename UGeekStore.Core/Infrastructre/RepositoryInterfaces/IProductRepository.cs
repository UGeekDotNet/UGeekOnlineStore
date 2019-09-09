using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Entities;
using UGeekStore.Core.Infrastructre.RepositoryAbstraction;
using UGeekStore.Core.ViewModels;

namespace UGeekStore.Core.Infrastructre.RepositoryInterfaces
{
   public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<List<AlphabeticalModel>> GetAlphabeticProducts();
        Task<List<ProductSalesModel>> ProductSalesForAllTime();

    }
}
