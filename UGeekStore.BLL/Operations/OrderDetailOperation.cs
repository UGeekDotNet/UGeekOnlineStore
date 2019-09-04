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
        public async Task<OrderDetailModel> GetOrderDetail(long OrderId, long ProductId)
        {
            var OrderDetail = await _repositoryManager.OrderDetails
                                                   .GetSingleAsync(item => item.OrderID == OrderId
                                                                    && item.ProductID==ProductId);
            var result = _mapper.Map<OrderDetailModel>(OrderDetail);
            return result;
        }

        public async Task AddOrderDetail(OrderDetailModel OrderDetail)
        {
            var result = _mapper.Map<OrderDetail>(OrderDetail);
            _repositoryManager.OrderDetails.Add(result);
            await _repositoryManager.CompleteAsync();
        }

        public async Task DeleteOrderDetail(OrderDetailModel OrderDetail)
        {
            var result = _mapper.Map<OrderDetail>(OrderDetail);
            _repositoryManager.OrderDetails.Delete(result);
            await _repositoryManager.CompleteAsync();
        }

        public async Task UpdateOrderDetail(OrderDetailModel OrderDetail)
        {
            var result = _mapper.Map<OrderDetail>(OrderDetail);
            _repositoryManager.OrderDetails.Update(result);
            await _repositoryManager.CompleteAsync();
        }
    }
}
