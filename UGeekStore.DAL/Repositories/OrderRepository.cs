using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Entities;
using UGeekStore.Core.Infrastructre.RepositoryInterfaces;
using UGeekStore.Core.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UGeekStore.DAL.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public decimal _price;
        public OrderRepository(StoreContext _context) : base(_context)
        {

        }
        public async Task<List<InvoicesModel>> Invoices(IOrderDetailRepository orders)
        {
            var result = await (from order in Context.Orders
                                join user in Context.Users
                                on order.UserID equals user.Id into OU
                                join orderDetail in Context.OrderDetails
                                on OU.FirstOrDefault().Id equals orderDetail.OrderID
                                select new
                                {
                                    order.Address
                                    , order.City
                                    , order.PostalCode
                                    , order.Country
                                    , OU.FirstOrDefault().Id
                                    , UserAdsress = OU.FirstOrDefault().Address
                                    , UserCity = OU.FirstOrDefault().City
                                    , UserPostalCode = OU.FirstOrDefault().PostalCode
                                    , UserCountry = OU.FirstOrDefault().Country
                                    , OrderID = OU.FirstOrDefault().Id
                                    , order.OrderDate
                                    , order.ShippedDate
                                    , Price = ((decimal)((decimal)orderDetail.Quantity * orderDetail.UnitPrice) * ((decimal)(1 - orderDetail.Discount) / 100) * 100)
                                    , orderDetail.ProductID
                                    , orderDetail.UnitPrice
                                    , orderDetail.Quantity
                                    , orderDetail.Discount
                                    ,
                                } into OUOD
                                join product in Context.Products
                                on OUOD.ProductID equals product.Id into OUODP
                                join supplier in Context.Suppliers
                                on OUODP.FirstOrDefault().SupplierID equals supplier.Id into OUODPS
                                select new InvoicesModel
                                {
                                    CompanyName = OUODPS.FirstOrDefault().CompanyName
                                    ,
                                    ShipAddres = OUOD.Address
                                    ,
                                    ShipCity = OUOD.City
                                    ,
                                    ShipPostalCode = OUOD.PostalCode
                                    ,
                                    ShipCountry = OUOD.Country
                                    ,
                                    UserId = OUOD.Id
                                    ,
                                    UserAddress = OUOD.UserAdsress
                                    ,
                                    UserCity = OUOD.UserCity
                                    ,
                                    UserPostalCode = OUOD.UserPostalCode
                                    ,
                                    UserCountry = OUOD.UserCountry
                                    ,
                                    OrderID = OUOD.OrderID
                                    ,
                                    OrderDate = OUOD.OrderDate
                                    ,
                                    OrderShippedDate = OUOD.ShippedDate
                                    ,
                                    ProductId = OUODP.FirstOrDefault().Id
                                    ,
                                    ProductName = OUODP.FirstOrDefault().Name
                                    ,
                                    UnitPrice = OUOD.UnitPrice
                                    ,
                                    Quantity = OUOD.Quantity
                                    ,
                                    Discount = OUOD.Discount
                                    ,
                                    OrderPrice = OUOD.Price
                                }).ToListAsync();
            result.Sum(x => x.OrderPrice);
            return result;
                     
        }
    }
}
