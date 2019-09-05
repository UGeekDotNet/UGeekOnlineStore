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
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierOperation _supplierOperation;

        public SupplierController(ISupplierOperation supplierOperation)
        {
            _supplierOperation = supplierOperation;
        }

        [HttpGet("{id}")]
        public Task<SupplierModel> GetSupplier([FromRoute]int id)
        {
            var result = _supplierOperation.GetSupplier(id);
            return result;
        }

        [HttpPost]
        public async Task AddSupplier([FromBody]SupplierModel supplier)
        {
            await _supplierOperation.AddSupplier(supplier);
        }

        [HttpPut]
        public async Task UpdateSupplier([FromBody]SupplierModel supplier)
        {
            await _supplierOperation.UpdateSupplier(supplier);
        }

        [HttpDelete("{id}")]
        public async Task DeleteSupplier([FromRoute]int id)
        {
            await _supplierOperation.DeleteSupplier(id);
        }
    }
}