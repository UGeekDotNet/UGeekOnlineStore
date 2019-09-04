using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Models;

namespace UGeekStore.Core.Infrastructre.BLLInterfaces
{
    public interface IProductOperation
    {
        Task<ProductModel> GetProduct(long id);
        Task AddProduct(ProductModel product);
        Task UpdateProduct(ProductModel productModel);
        Task DeleteProduct(long id);
    }
}
