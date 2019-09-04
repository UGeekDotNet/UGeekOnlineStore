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
    public class OrderOperation :IOrderOperation
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public OrderOperation(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<OrderModel> GetOrder(long id)
        {
            var order = await _repositoryManager.Orders
                                               .GetSingleAsync(item => item.Id == id);
            var result = _mapper.Map<OrderModel>(order);
            return result;
        }

        public async Task AddOrder(OrderModel order)
        {
            var result = _mapper.Map<Order>(order);
            _repositoryManager.Orders.Add(result);
            await _repositoryManager.CompleteAsync();
        }

        public async Task DeleteOrder(OrderModel order)
        {
            var result = _mapper.Map<Order>(order);
            _repositoryManager.Orders.Delete(result);
            await _repositoryManager.CompleteAsync();
        }
        public async Task UpdateOrder(OrderModel order)
        {
            var result = _mapper.Map<Order>(order);
            _repositoryManager.Orders.Update(result);
            await _repositoryManager.CompleteAsync();
        }
    }
}
