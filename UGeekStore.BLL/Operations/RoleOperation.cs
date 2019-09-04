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
    public class RoleOperation:IRoleOperation
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
            var role = await _repositoryManager.Roles.GetSingleAsync(x => x.Id == id);
            var result = _mapper.Map<RoleModel>(role);
            return result;
        }
        public async Task AddRole(RoleModel role)
        {
            var result = _mapper.Map<Role>(role);

            _repositoryManager.Roles.Add(result);
            await _repositoryManager.CompleteAsync();
        }
        public async Task UpdateRole(RoleModel roleModel)
        {
            var updateRole = _mapper.Map<Role>(roleModel);
            _repositoryManager.Roles.Update(updateRole);
            await _repositoryManager.CompleteAsync();
        }
        public async Task DeleteRole(long id)
        {
            _repositoryManager.Roles.DeleteWhere(x => x.Id == id);
            await _repositoryManager.CompleteAsync();
        }
    }
}
