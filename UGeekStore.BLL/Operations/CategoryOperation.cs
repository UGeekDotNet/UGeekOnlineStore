using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Entities;
using UGeekStore.Core.Infrastructre.BLLInterfaces;
using UGeekStore.Core.Infrastructre.RepositoryAbstraction;
using UGeekStore.Core.Models;
using UGeekStore.DAL.Entities;


namespace UGeekStore.BLL.Operations
{
    public class CategoryOperation : ICategoryOperation
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
            var category = await _repositoryManager.Categories
                                                   .GetSingleAsync(item => item.Id == id);
            var result = _mapper.Map<CategoryModel>(category);
            return result;
        }

        public async Task AddCategory(CategoryModel category)
        {
            var result = _mapper.Map<Category>(category);
            _repositoryManager.Categories.Add(result);
            await _repositoryManager.CompleteAsync();
        }

        public async Task DeleteCategory(CategoryModel category)
        {
            var result = _mapper.Map<Category>(category);
            _repositoryManager.Categories.Delete(result);
            await _repositoryManager.CompleteAsync();
        }

        public async Task UpdateCategory(CategoryModel category)
        {
            var result = _mapper.Map<Category>(category);
            _repositoryManager.Categories.Update(result);
            await _repositoryManager.CompleteAsync();
        }
    }
}
