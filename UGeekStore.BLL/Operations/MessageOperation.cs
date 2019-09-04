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
    public class MessageOperation : IMessageOperation
    {
        private readonly  IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public MessageOperation(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this._repositoryManager = repositoryManager;
            this._mapper = mapper;
        }

        public async Task<MessageModel> GetMessage(long id)
        {

            var message = await _repositoryManager.Message.GetSingleAsync(item => item.Id == id);
             var result  = _mapper.Map<MessageModel>(message);

            return result;

        }
        public async Task AddMessage(MessageModel message)
        {
            var result = _mapper.Map<Message>(message);
            _repositoryManager.Message.Add(result);

            await _repositoryManager.CompleteAsync();
            
        }
        public async Task RemoveMessage(MessageModel message)
        {
            var result = _mapper.Map<Message>(message);
            _repositoryManager.Message.Delete(result);
            await _repositoryManager.CompleteAsync();


        }
        public async Task UpdateMessage(MessageModel message)
        {
            var result = _mapper.Map<Message>(message);
            _repositoryManager.Message.Update(result);

            await _repositoryManager.CompleteAsync();

        }
    }
}
