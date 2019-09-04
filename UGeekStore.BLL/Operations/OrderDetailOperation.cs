using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Infrastructre.BLLInterfaces;
using UGeekStore.Core.Infrastructre.RepositoryAbstraction;
using UGeekStore.Core.Models;
using UGeekStore.Core.Entities;

namespace UGeekStore.BLL.Operations
{
    public class OrderDetailOperation : IOrderDetailOperation
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public OrderDetailOperation(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task AddOrderDetail(OrderDetailModel orderdetail)
        {
            var result = _mapper.Map<OrderDetail>(orderdetail);
            _repositoryManager.OrderDetails.Add(result);
            await _repositoryManager.CompleteAsync();
        }

        public async Task DeleteOrderDetail(OrderDetailModel orderdetail)
        {
            var result = _mapper.Map<OrderDetail>(orderdetail);
            _repositoryManager.OrderDetails.Delete(result);
            await _repositoryManager.CompleteAsync();
        }

        public async Task UpdateOrderDetail(OrderDetailModel orderdetail)
        {
            var result = _mapper.Map<OrderDetail>(orderdetail);
            _repositoryManager.OrderDetails.Update(result);
            await _repositoryManager.CompleteAsync();
        }
    }
}
