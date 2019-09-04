using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Entities;
using UGeekStore.Core.Infrastructre.BLLInterfaces;
using UGeekStore.Core.Infrastructre.RepositoryAbstraction;
using UGeekStore.Core.Models;

namespace UGeekStore.BLL.Operations
{
    public class CategoryOperation:ICategoryOperation
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CategoryOperation(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CategoryModel> GetCategory(long id)
        {
            var category = await _repositoryManager.Categories.GetSingleAsync(x => x.Id == id);
            var result = _mapper.Map<CategoryModel>(category);
            return result;
        }
        public async Task AddCategory(CategoryModel category)
        {
            var result = _mapper.Map<Category>(category);
            _repositoryManager.Categories.Add(result);
            await _repositoryManager.CompleteAsync();
        }
        public async Task UpdateCategory(CategoryModel categoryModel)
        {
            var category = await _repositoryManager.Categories.GetSingleAsync(x => x.Id == categoryModel.Id);
            var updateCategory = _mapper.Map<Category>(categoryModel);
            updateCategory = category;
            _repositoryManager.Categories.Update(updateCategory);
            await _repositoryManager.CompleteAsync();
        }
        public async Task DeleteCategory(long id)
        {
            _repositoryManager.Categories.DeleteWhere(x => x.Id == id);
            await _repositoryManager.CompleteAsync();
        }
    }
}
