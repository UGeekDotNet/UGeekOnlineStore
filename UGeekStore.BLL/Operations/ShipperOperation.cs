﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Infrastructre.BLLInterfaces;
using UGeekStore.Core.Infrastructre.RepositoryAbstraction;
using UGeekStore.Core.Models;
using UGeekStore.DAL.Entities;

namespace UGeekStore.BLL.Operations
{
    public class ShipperOperation : IShipperOperation
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public ShipperOperation(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ShipperModel> GetShipper(long id)
        {
            var shipper = await _repositoryManager.Shippers
                                                  .GetSingleAsync(item => item.Id == id);
            var result = _mapper.Map<ShipperModel>(shipper);
            return result;
        }

        public async Task AddShipper(ShipperModel shipper)
        {
            var result = _mapper.Map<Shipper>(shipper);
            _repositoryManager.Shippers.Add(result);
            await _repositoryManager.CompleteAsync();
        }

        public async Task DeleteShipper(ShipperModel shipper)
        {
            var result = _mapper.Map<Shipper>(shipper);
            _repositoryManager.Shippers.Delete(result);
            await _repositoryManager.CompleteAsync();
        }

        public async Task UpdateShipper(ShipperModel shipper)
        {
            var result = _mapper.Map<Shipper>(shipper);
            _repositoryManager.Shippers.Update(result);
            await _repositoryManager.CompleteAsync();
        }
    }
}
