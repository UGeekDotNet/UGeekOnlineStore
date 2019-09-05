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
    public class OrderDetailOperation : IOrderDetailOperation
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public OrderDetailOperation(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<OrderDetailModel> GetOrderDetail(long orderId, long productId)
        {
            var orderDetail = await _repositoryManager.OrderDetails.GetSingleAsync(x => x.OrderID == orderId && x.ProductID == productId);
            var result = _mapper.Map<OrderDetailModel>(orderDetail);
            return result;
        }
        public async Task AddOrderDetails(OrderDetailModel orderDetailsModel)
        {
            var result = _mapper.Map<OrderDetail>(orderDetailsModel);
            _repositoryManager.OrderDetails.Add(result);
            await _repositoryManager.CompleteAsync();
        }
        public async Task UpdateOrderDetail(OrderDetailModel orderDetailModel)
        {
            var updateOrderDetail = _mapper.Map<OrderDetail>(orderDetailModel);
            _repositoryManager.OrderDetails.Update(updateOrderDetail);
            await _repositoryManager.CompleteAsync();
        }
        public async Task DeleteOrderDetail(long orderId, long productId)
        {
            _repositoryManager.OrderDetails.DeleteWhere(x => x.OrderID == orderId && x.ProductID == productId);
            await _repositoryManager.CompleteAsync();
        }
    }
}
