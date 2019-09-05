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
    public class MessageController : ControllerBase
    {
        private readonly IMessageOperation _messageOperation;

        public MessageController(IMessageOperation messageOperation)
        {
            _messageOperation = messageOperation;
        }

        [HttpGet("{id}")]
        public Task<MessageModel> GetMessage([FromRoute]int id)
        {
            var result = _messageOperation.GetMessage(id);
            return result;
        }

        [HttpPost]
        public async Task AddMessage([FromBody]MessageModel message)
        {
            await _messageOperation.AddMessage(message);
        }

        [HttpPut]
        public async Task UpdateMessage([FromBody]MessageModel message)
        {
            await _messageOperation.UpdateMessage(message);
        }

        [HttpDelete("{id}")]
        public async Task DeleteMessage([FromRoute]int id)
        {
            await _messageOperation.DeleteMessage(id);
        }
    }
}