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
    public class MessageController : ControllerBase
    {
        private readonly IMessageOperation _messageOperation;
        public MessageController(IMessageOperation messageOperation)
        {
            _messageOperation=messageOperation;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Task<MessageModel> GetMessage([FromRoute]int id)
        {
            var result = _messageOperation.GetMessage(id);
            return result;

        }

        // POST api/<controller>
        [HttpPost]
        public async Task AddMessage([FromBody]MessageModel message)
        {
            await _messageOperation.AddMessage(message);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task UpdateMessage([FromBody]MessageModel message)
        {
            await _messageOperation.UpdateMessage(message);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task DeleteMessage([FromRoute]int id)
        {
            await _messageOperation.DeleteMessage(id);
        }
    }
}
