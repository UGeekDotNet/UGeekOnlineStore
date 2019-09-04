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
    public class OrderOperation:IOrderOperation
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public OrderOperation(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<OrderModel> GetOrder (long id)
        {
            var order = await _repositoryManager.Orders.GetSingleAsync(x => x.Id == id);
            var result = _mapper.Map<OrderModel>(order);
            return result;
        }
        public async Task AddOrder(OrderModel order)
        {
            var result = _mapper.Map<Order>(order);
            _repositoryManager.Orders.Add(result);
            await _repositoryManager.CompleteAsync();
        }
        public async Task UpdateOrder(OrderModel orderModel)
        {
            var updateOrder = _mapper.Map<Order>(orderModel);
            _repositoryManager.Orders.Update(updateOrder);
            await _repositoryManager.CompleteAsync();
        }
        public async Task DeleteOrder(long id)
        {
            _repositoryManager.Orders.DeleteWhere(x => x.Id == id);
            await _repositoryManager.CompleteAsync();
        }
    }
}
