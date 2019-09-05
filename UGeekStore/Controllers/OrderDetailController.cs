using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UGeekStore.Core.Infrastructre.BLLInterfaces;
using UGeekStore.Core.Models;

namespace UGeekStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailOperation _orderDetailOperation;

        public OrderDetailController(IOrderDetailOperation orderDetailOperation)
        {
            _orderDetailOperation = orderDetailOperation;
        }

        [HttpGet("{id}")]
        public Task<OrderDetailModel> GetOrderDetail([FromRoute]int orderId, [FromRoute] int productId)
        {
            var result = _orderDetailOperation.GetOrderDetail(orderId,productId);
            return result;
        }

        [HttpPost]
        public async Task AddOrderDetail([FromBody]OrderDetailModel orderDetail)
        {
            await _orderDetailOperation.AddOrderDetails(orderDetail);
        }

        [HttpPut]
        public async Task UpdateOrderDetail([FromBody]OrderDetailModel orderDetail)
        {
            await _orderDetailOperation.UpdateOrderDetail(orderDetail);
        }

        [HttpDelete("{id}")]
        public async Task DeleteOrderDetail([FromRoute]int orderId, [FromRoute] int productId)
        {
            await _orderDetailOperation.DeleteOrderDetail(orderId,productId);
        }
    }
}