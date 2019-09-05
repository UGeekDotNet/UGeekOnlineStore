using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UGeekStore.Core.Infrastructre.BLLInterfaces;
using UGeekStore.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UGeekStore.Controllers
{
    [Route("api/[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailOperation _orderDetailOperation;
        public OrderDetailController(IOrderDetailOperation orderDetailOperation)
        {
            _orderDetailOperation = orderDetailOperation;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Task<OrderDetailModel> GetOrderDetail([FromRoute]int productId,[FromRoute]int orderId)
        {
            var result = _orderDetailOperation.GetOrderDetail(orderId,productId);
            return result;

        }

        // POST api/<controller>
        [HttpPost]
        public async Task AddOrderDetail([FromBody]OrderDetailModel orderDetail)
        {
            await _orderDetailOperation.AddOrderDetails(orderDetail);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task UpdateOrderDetail([FromBody]OrderDetailModel orderDetail)
        {
            await _orderDetailOperation.UpdateOrderDetail(orderDetail);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task DeletOrderDetail([FromRoute]int productId,[FromRoute] int orderId)
        {
            await _orderDetailOperation.DeleteOrderDetail(orderId,productId);
        }
    }
}
