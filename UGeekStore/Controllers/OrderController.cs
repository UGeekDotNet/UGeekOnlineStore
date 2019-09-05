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
    public class OrderController : ControllerBase
    {
        private readonly IOrderOperation _orderOperation;

        public OrderController(IOrderOperation orderOperation)
        {
            _orderOperation = orderOperation;
        }

        [HttpGet("{id}")]
        public Task<OrderModel> GetOrder([FromRoute]int id)
        {
            var result = _orderOperation.GetOrder(id);
            return result;
        }

        [HttpPost]
        public async Task AddOrder([FromBody]OrderModel order)
        {
            await _orderOperation.AddOrder(order);
        }

        [HttpPut]
        public async Task UpdateOrder([FromBody]OrderModel order)
        {
            await _orderOperation.UpdateOrder(order);
        }

        [HttpDelete("{id}")]
        public async Task DeleteOrder([FromRoute]int id)
        {
            await _orderOperation.DeleteOrder(id);
        }
    }
}