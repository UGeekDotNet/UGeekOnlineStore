using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Models;

namespace UGeekStore.Core.Infrastructre.BLLInterfaces
{
    public  interface IOrderOperation
    {
        Task<OrderModel> GetOrder(long id);
        Task AddOrder(OrderModel order);
        Task UpdateOrder(OrderModel orderModel);
        Task DeleteOrder(long id);
    }
}
