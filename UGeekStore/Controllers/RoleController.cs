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
    public class RoleController : ControllerBase
    {
        private readonly  IRoleOperation _roleOperation;

        public RoleController(IRoleOperation roleOperation)
        {
            _roleOperation = roleOperation;
        }

        [HttpGet("{id}")]
        public Task<RoleModel> GetRole([FromRoute]int id)
        {
            var result = _roleOperation.GetRole(id);
            return result;
        }

        [HttpPost]
        public async Task AddRole([FromBody]RoleModel role)
        {
            await _roleOperation.AddRole(role);
        }

        [HttpPut]
        public async Task UpdateRole([FromBody]RoleModel role)
        {
            await _roleOperation.UpdateRole(role);
        }

        [HttpDelete("{id}")]
        public async Task DeleteRole([FromRoute]int id)
        {
            await _roleOperation.DeleteRole(id);
        }
    }
}