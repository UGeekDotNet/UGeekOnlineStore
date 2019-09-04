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
    public class CategoryOperation : ICategoryOperation
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CategoryOperation(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this._repositoryManager = repositoryManager;
            this._mapper = mapper;

        }

        public async Task<CategoryModel> GetCategory(long id)
        {
            var category = await _repositoryManager.Category.GetSingleAsync(item => item.Id == id);

            var result = _mapper.Map<CategoryModel>(category);

            return result;
        }

        public async Task AddCategory(CategoryModel category)
        {
            var result = _mapper.Map<Category>(category);

            _repositoryManager.Category.Add(result);

            await _repositoryManager.CompleteAsync();
        }

        public async Task RemoveCategory(long id)
        {

            _repositoryManager.Category.DeleteWhere(x => x.Id == id);
            await _repositoryManager.CompleteAsync();

        }

        public async Task UpdateCategory(CategoryModel category)
        {
            var result = _mapper.Map<Category>(category);
            _repositoryManager.Category.Update(result);
            await _repositoryManager.CompleteAsync();
        }
    }
}
