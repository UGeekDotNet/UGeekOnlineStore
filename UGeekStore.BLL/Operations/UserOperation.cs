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
    public class UserOperation : IUserOperation
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UserOperation(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<UserModel> GetUser(long id)
        {
            var user = await _repositoryManager.Users
                                               .GetSingleAsync(item => item.Id == id);
            var result = _mapper.Map<UserModel>(user);
            return result;
        }

        public async Task AddUser(UserModel user)
        {
            var result = _mapper.Map<User>(user);
            _repositoryManager.Users.Add(result);
            await _repositoryManager.CompleteAsync();
        }

        public async Task DeleteUser(UserModel user)
        {
            var result = _mapper.Map<User>(user);
            _repositoryManager.Users.Delete(result);
            await _repositoryManager.CompleteAsync();
        }

        public async Task UpdateUser(UserModel user)
        {
            var result = _mapper.Map<User>(user);
            _repositoryManager.Users.Update(result);
            await _repositoryManager.CompleteAsync();
        }
    }
}
