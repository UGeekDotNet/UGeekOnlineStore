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
    public class SupplierOperation:ISupplierOperation
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public SupplierOperation(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<SupplierModel> GetSupplier(long id)
        {
            var supplier = await _repositoryManager.Suppliers.GetSingleAsync(x => x.Id==id);
            var result = _mapper.Map<SupplierModel>(supplier);
            return result;
        }
        public async Task AddSupplier(SupplierModel supplier)
        {
            var result = _mapper.Map<Supplier>(supplier);
            _repositoryManager.Suppliers.Add(result);
            await _repositoryManager.CompleteAsync();
        }
        public async Task UpdateSupplier(SupplierModel supplierModel)
        {
            var supplier = await _repositoryManager.Suppliers.GetSingleAsync(x => x.Id == supplierModel.Id);
            var updateSupplier = _mapper.Map<Supplier>(supplierModel);
            supplier = updateSupplier;
            _repositoryManager.Suppliers.Update(supplier);
            await _repositoryManager.CompleteAsync();
        }
        public async Task DeleteSupplier(long id)
        {
            _repositoryManager.Suppliers.DeleteWhere(x => x.Id == id);
            await _repositoryManager.CompleteAsync();
        }

    }
}
