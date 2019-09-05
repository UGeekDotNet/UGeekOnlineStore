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
    public class UserController : ControllerBase
    {
        private readonly IUserOperation _userOperation;

        public UserController(IUserOperation userOperation)
        {
            _userOperation = userOperation;
        }

        [HttpGet("{id}")]
        public Task<UserModel> GetUser([FromRoute]int id)
        {
            var result = _userOperation.GetUser(id);
            return result;
        }

        [HttpPost]
        public async Task AddUser([FromBody]UserModel user)
        {
            await _userOperation.AddUser(user);
        }

        [HttpPut]
        public async Task UpdateUser([FromBody]UserModel user)
        {
            await _userOperation.UpdateUser(user);
        }

        [HttpDelete("{id}")]
        public async Task DeleteUser([FromRoute]int id)
        {
            await _userOperation.DeleteUser(id);
        }
    }
}