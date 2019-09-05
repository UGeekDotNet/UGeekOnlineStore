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
    public class RoleController : ControllerBase
    {
        private readonly IRoleOperation _roleOperation;
        public RoleController(IRoleOperation roleOperation)
        {
            _roleOperation = roleOperation;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Task<RoleModel> GetRole([FromRoute]int id)
        {
            var result = _roleOperation.GetRole(id);
            return result;

        }

        // POST api/<controller>
        [HttpPost]
        public async Task AddRole([FromBody]RoleModel role)
        {
            await _roleOperation.AddRole(role);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task UpdateRole([FromBody]RoleModel role)
        {
            await _roleOperation.UpdateRole(role);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task DeleteRole([FromRoute]int id)
        {
            await _roleOperation.DeleteRole(id);
        }
    }
}
