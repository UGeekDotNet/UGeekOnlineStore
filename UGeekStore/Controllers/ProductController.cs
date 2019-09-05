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
    public class ProductController : ControllerBase
    {
        private readonly IProductOperation _productOperation;

        public ProductController(IProductOperation productOperation)
        {
            _productOperation = productOperation;
        }

        [HttpGet("{id}")]
        public Task<ProductModel> GetProduct([FromRoute]int id)
        {
            var result = _productOperation.GetProduct(id);
            return result;
        }

        [HttpPost]
        public async Task AddProduct([FromBody]ProductModel product)
        {
            await _productOperation.AddProduct(product);
        }

        [HttpPut]
        public async Task UpdateProduct([FromBody]ProductModel product)
        {
            await _productOperation.UpdateProduct(product);
        }

        [HttpDelete("{id}")]
        public async Task DeleteProduct([FromRoute]int id)
        {
            await _productOperation.DeleteProduct(id);
        }
    }
}