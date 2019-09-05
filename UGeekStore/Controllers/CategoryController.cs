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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryOperation _categoryOperation;

        public CategoryController(ICategoryOperation categoryOperation)
        {
            _categoryOperation = categoryOperation;
        }

        // api/Categories/5
        // id = 5 tvyal depqum
        [HttpGet("{id}")]
        public Task<CategoryModel> GetCategory([FromRoute]int id)
        {
            var result = _categoryOperation.GetCategory(id);
            return result;
        }

        // api/Categories
        [HttpPost]
        public async Task AddCategory([FromBody]CategoryModel category)
        {
            await _categoryOperation.AddCategory(category);
        }

        // api/Categories
        [HttpPut]
        public async Task UpdateCategory([FromBody]CategoryModel category)
        {
            await _categoryOperation.UpdateCategory(category);
        }

        // api/Categories/5
        // id = 5 tvyal depqum
        [HttpDelete("{id}")]
        public async Task DeleteCategory([FromRoute]int id)
        {
            await _categoryOperation.DeleteCategory(id);
        }
    }
}