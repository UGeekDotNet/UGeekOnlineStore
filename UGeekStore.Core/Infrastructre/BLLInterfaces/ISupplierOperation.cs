using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Models;

namespace UGeekStore.Core.Infrastructre.BLLInterfaces
{
    public interface ISupplierOperation
    {
        Task<SupplierModel> GetSupplier(long id);
        Task AddSupplier(SupplierModel supplier);
        Task UpdateSupplier(SupplierModel supplierModel);
        Task DeleteSupplier(long id);
    }
}
