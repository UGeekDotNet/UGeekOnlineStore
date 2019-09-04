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
    public class OrderDetailOperattion : IOrderDetailOperation
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderDetailOperattion(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this._repositoryManager = repositoryManager;
            this._mapper = mapper;

        }

        public async Task<OrderDetailModel> GetOrderDetail()//?
        {
            var orderdetail = await _repositoryManager.OrderDetail.GetAllAsync();
            var result = _mapper.Map<OrderDetailModel>(orderdetail);
            return result;
        }
        public async Task AddOrderDetail(OrderDetailModel orderDetail)
        {
            var result = _mapper.Map<OrderDetail>(orderDetail);
            _repositoryManager.OrderDetail.Add(result);
            await _repositoryManager.CompleteAsync();

        }
        public async Task RemoveOrderDetail(long productId,long OrderId)
        {
            _repositoryManager.OrderDetail.DeleteWhere(x => x.OrderID==OrderId && x.ProductID==productId);

            await _repositoryManager.CompleteAsync();
        }
        public  async Task UpdateOrderDetail(OrderDetailModel orderDetail)
        {
            var result = _mapper.Map<OrderDetail>(orderDetail);
            _repositoryManager.OrderDetail.Add(result);

            await _repositoryManager.CompleteAsync();
        }

    }
}
