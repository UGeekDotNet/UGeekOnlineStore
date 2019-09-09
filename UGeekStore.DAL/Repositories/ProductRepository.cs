using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Entities;
using UGeekStore.Core.Infrastructre.RepositoryInterfaces;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UGeekStore.Core.ViewModels;


namespace UGeekStore.DAL.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(StoreContext _context) : base(_context)
        {
        }
        public async Task<List<AlphabeticalModel>> GetAlphabeticProducts()
        {
            var result = await (from prod in Context.Products
                                join category in Context.Categories
                                on prod.CategoryID equals category.Id
                                select new AlphabeticalModel
                                {
                                    Id = prod.Id
                                   ,
                                    Name = prod.Name
                                   ,
                                    SupplierId = prod.SupplierID
                                   ,
                                    CategoryId = prod.CategoryID
                                   ,
                                    UnitPrice = prod.UnitPrice
                                   ,
                                    CategoryName = category.Name
                                }).ToListAsync();
            return result;
        }
        public async Task<List<ProductSalesModel>> ProductSalesForAllTime()
        {
            var result = await (from category in Context.Categories
                                join product in Context.Products
                                on category.Id equals product.CategoryID
                                join orderDeail in Context.OrderDetails
                                on product.Id equals orderDeail.ProductID
                                group new { product, category, orderDeail } by new { ProductName = product.Name, CategoryName = category.Name } into CPODG
                                select new ProductSalesModel
                                {
                                    Sales = CPODG.Sum(x => (((decimal)x.orderDeail.Quantity * x.orderDeail.UnitPrice) * ((decimal)(1 - x.orderDeail.Discount) / 100) * 100)),
                                    CategoryName = CPODG.Key.CategoryName,
                                    ProductName = CPODG.Key.ProductName
                                }).ToListAsync();
            return result;
        }
    }
}
