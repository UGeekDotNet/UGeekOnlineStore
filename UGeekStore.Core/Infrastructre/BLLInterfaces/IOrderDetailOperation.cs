using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Models;

namespace UGeekStore.Core.Infrastructre.BLLInterfaces
{
    public interface IOrderDetailOperation
    {
        Task<OrderDetailModel> GetOrderDetails(long orderId, long productId);
        Task AddOrderDetails(OrderDetailModel orderDetailsModel);
        Task UpdateOrderDetail(OrderDetailModel orderDetailModel);
        Task DeleteCategory(long orderId, long productId);
    }
}
