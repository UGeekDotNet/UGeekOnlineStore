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
    public class OrderController : ControllerBase
    {
        private readonly IOrderOperation _orderOperation;
        public OrderController(IOrderOperation orderOperation)
        {
            _orderOperation = orderOperation;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Task<OrderModel> GetOrder([FromRoute]int id)
        {
            var result = _orderOperation.GetOrder(id);
            return result;

        }

        // POST api/<controller>
        [HttpPost]
        public async Task AddOrder([FromBody]OrderModel order)
        {
            await _orderOperation.AddOrder(order);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task UpdateOrder([FromBody]OrderModel order)
        {
            await _orderOperation.UpdateOrder(order);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task DeleteOrder([FromRoute]int id)
        {
            await _orderOperation.DeleteOrder(id);
        }
    }
}
