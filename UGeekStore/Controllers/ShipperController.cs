using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UGeekStore.Core.Infrastructre.BLLInterfaces;
using UGeekStore.Core.Models;

namespace UGeekStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperOperation _shipperOperation;

        public ShipperController(IShipperOperation shipperOperation)
        {
            _shipperOperation = shipperOperation;
        }

        [HttpGet("{id}")]
        public Task<ShipperModel> GetShipper([FromRoute]int id)
        {
            var result = _shipperOperation.GetShipper(id);
            return result;
        }

        [HttpPost]
        public async Task AddShipper([FromBody]ShipperModel shipper)
        {
            await _shipperOperation.AddShipper(shipper);
        }

        [HttpPut]
        public async Task UpdateShipper([FromBody]ShipperModel shipper)
        {
            await _shipperOperation.UpdateShipper(shipper);
        }

        [HttpDelete("{id}")]
        public async Task DeleteShipper([FromRoute]int id)
        {
            await _shipperOperation.DeleteShipper(id);
        }
    }
}