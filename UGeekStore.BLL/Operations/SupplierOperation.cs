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
    public class SupplierOperation : ISupplierOperation
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly  IMapper _mapper;

        public SupplierOperation(IRepositoryManager repositoryManager,IMapper mapper)
        {
            this._repositoryManager = repositoryManager;
            this._mapper = mapper;
        }
        public async Task<SupplierModel> GetSupplier(long id)
        {
            var supplier = await _repositoryManager.Supplie.GetSingleAsync(item => item.Id == id);

            var result = _mapper.Map<SupplierModel>(supplier);

            return result;
        }
        public async Task AddSupplier(SupplierModel supplier)
        {
            var result = _mapper.Map<Supplier>(supplier);
            _repositoryManager.Supplie.Add(result);
            await _repositoryManager.CompleteAsync();
        }
        public async Task RemoveSupplier(SupplierModel supplier)
        {
            var result = _mapper.Map<Supplier>(supplier);
            _repositoryManager.Supplie.Delete(result);
            await _repositoryManager.CompleteAsync();
        }
        public async Task UpdateSupplier(SupplierModel supplier)
        {
            var result = _mapper.Map<Supplier>(supplier);
            _repositoryManager.Supplie.Update(result);
            await _repositoryManager.CompleteAsync();
        }
    }
}
