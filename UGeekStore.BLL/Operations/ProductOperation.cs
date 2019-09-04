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
    public class ProductOperation:IProductOperation
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public ProductOperation(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ProductModel> GetProduct(long id)
        {
            var product = await _repositoryManager.Products.GetSingleAsync(x => x.Id == id);
            var result = _mapper.Map<ProductModel>(product);
            return result;
        }
        public async Task AddProduct(ProductModel product)
        {
            var result = _mapper.Map<Product>(product);
            _repositoryManager.Products.Add(result);
            await _repositoryManager.CompleteAsync();
        }
        public async Task UpdateProduct(ProductModel productModel)
        {
            var product = await _repositoryManager.Products.GetSingleAsync(x => x.Id == productModel.Id);
            var updateProduct = _mapper.Map<Product>(productModel);
            updateProduct = product;
            _repositoryManager.Products.Update(updateProduct);
            await _repositoryManager.CompleteAsync();
        }
        public async Task DeleteProduct(long id)
        {
            _repositoryManager.Products.DeleteWhere(x => x.Id == id);
            await _repositoryManager.CompleteAsync();
        }
    }
}
