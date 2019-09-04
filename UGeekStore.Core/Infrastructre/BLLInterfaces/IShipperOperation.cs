using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Models;

namespace UGeekStore.Core.Infrastructre.BLLInterfaces
{
    public interface IShipperOperation
    {
        Task<ShipperModel> GetShipper(long id);
        Task AddShipper(ShipperModel shipper);
        Task UpdateShipper(ShipperModel shipperModel);
        Task DeleteShipper(long id);
    }
}
