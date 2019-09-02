using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Infrastructre.RepositoryInterfaces;

namespace UGeekStore.Core.Infrastructre.RepositoryAbstraction
{
    public interface IRepositoryManager
    {
        IShipperRepository Shippers { get; }

        Task<int> CompleteAsync();
        int Complete();
    }
}
