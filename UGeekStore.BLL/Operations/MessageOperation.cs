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
    public class MessageOperation:IMessageOperation
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public MessageOperation(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<MessageModel> GetMessage(long id)
        {
            var message = await _repositoryManager.Messages.GetSingleAsync(x => x.Id == id);
            var result = _mapper.Map<MessageModel>(message);
            return result;
        }
        public async Task AddMessage(MessageModel message)
        {
            var result = _mapper.Map<Message>(message);
            _repositoryManager.Messages.Add(result);
            await _repositoryManager.CompleteAsync();
        }
        public async Task UpdateMessage(MessageModel messageModel)
        {
            var updateMessage = _mapper.Map<Message>(messageModel);
            _repositoryManager.Messages.Update(updateMessage);
            await _repositoryManager.CompleteAsync();
        }
        public async Task DeleteMessage(long id)
        {
            _repositoryManager.Messages.DeleteWhere(x => x.Id == id);
            await _repositoryManager.CompleteAsync();
        }
    }
}
