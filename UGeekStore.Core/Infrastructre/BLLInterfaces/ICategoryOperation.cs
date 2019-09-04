using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Models;

namespace UGeekStore.Core.Infrastructre.BLLInterfaces
{
    public interface ICategoryOperation
    {
        Task<CategoryModel> GetCategory(long id);
         Task AddCategory(CategoryModel category);
         Task UpdateCategory(CategoryModel categoryModel);
         Task DeleteCategory(long id);
        
    }
}
