using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UGeekStore.Core.Infrastructre.BLLInterfaces;
using UGeekStore.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UGeekStore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserOperation _userOperation;
        public UserController(IUserOperation userOperation)
        {
            _userOperation = userOperation;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Task<UserModel> GetUser([FromRoute]int id)
        {
            var result = _userOperation.GetUser(id);
            return result;

        }
        // GET api/<controller>/5
        [HttpGet("fromToken")]
        public Task<UserModel> GetUserFromToken()
        {
            var id = TokenManager.GetUserId(User);

            var result = _userOperation.GetUser(id);
            return result;

        }

        // POST api/<controller>
        // registration
        [HttpPost]
        [AllowAnonymous]
        public async Task AddUser([FromBody]UserModel user)
        {
            await _userOperation.AddUser(user);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task UpdateUser([FromBody]UserModel user)
        {
            await _userOperation.UpdateUser(user);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task DeleteUser([FromRoute]int id)
        {
            await _userOperation.DeleteUser(id);
        }
    }
}
