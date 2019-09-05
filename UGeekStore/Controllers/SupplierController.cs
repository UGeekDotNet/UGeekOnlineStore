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
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierOperation _supplierOperation;
        public SupplierController(ISupplierOperation supplierOperation)
        {
            _supplierOperation = supplierOperation;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Task<SupplierModel> GetSupplier([FromRoute]int id)
        {
            var result = _supplierOperation.GetSupplier(id);
            return result;

        }

        // POST api/<controller>
        [HttpPost]
        public async Task AddSupplier([FromBody]SupplierModel supplier)
        {
            await _supplierOperation.AddSupplier(supplier);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task UpdateSupplier([FromBody]SupplierModel supplier)
        {
            await _supplierOperation.UpdateSupplier(supplier);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task DeleteSupplier([FromRoute]int id)
        {
            await _supplierOperation.DeleteSupplier(id);
        }
    }
}
