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
    public class RoleOperation : IRoleOperation
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public RoleOperation(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<RoleModel> GetRole(long id)
        {
            var role = await _repositoryManager.Roles
                                               .GetSingleAsync(item => item.Id == id);
            var result = _mapper.Map<RoleModel>(role);
            return result;
        }

        public async Task AddRole(RoleModel role)
        {
            var result = _mapper.Map<Role>(role);
            _repositoryManager.Roles.Add(result);
            await _repositoryManager.CompleteAsync();
        }

        public async Task DeleteRole(RoleModel role)
        {
            var result = _mapper.Map<Role>(role);
            _repositoryManager.Roles.Delete(result);
            await _repositoryManager.CompleteAsync();
        }

        public async Task UpdateRole(RoleModel role)
        {
            var result = _mapper.Map<Role>(role);
            _repositoryManager.Roles.Update(result);
            await _repositoryManager.CompleteAsync();
        }
    }
}
