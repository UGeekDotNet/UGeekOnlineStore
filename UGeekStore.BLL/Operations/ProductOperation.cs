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
    public class ProductOperation : IProductOperation
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductOperation(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this._repositoryManager = repositoryManager;
            this._mapper = mapper;
        }

        public async Task<ProductModel> GetProduct(long id)
        {
           var product = await _repositoryManager.Product.GetSingleAsync(item => item.Id == id);
            var result = _mapper.Map<ProductModel>(product);
            return result;
        }
        public async Task AddProduct(ProductModel product)
        {
            var result = _mapper.Map<Product>(product);
            _repositoryManager.Product.Add(result);

            await _repositoryManager.CompleteAsync();


        }
        public async Task RemoveProduct(long id)
        {
            _repositoryManager.Product.DeleteWhere(x => x.Id == id);

            await _repositoryManager.CompleteAsync();
        }
        public async Task UpdateProduct(ProductModel product)
        {
            var result = _mapper.Map<Product>(product);
            _repositoryManager.Product.Update(result);
            await _repositoryManager.CompleteAsync();
        }
    }
}
