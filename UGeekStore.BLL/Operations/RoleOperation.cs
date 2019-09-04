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
    public class RoleOperation : IRoleOperation
    {
       private readonly IRepositoryManager _repositoryManager;
       private readonly IMapper _mapper;
        public RoleOperation(IRepositoryManager repositoryManager, IMapper mapper)
        {

            this._repositoryManager = repositoryManager;
            this._mapper = mapper;
        }

        public async Task<RoleOperation> GetRole(long id)
        {
            var role = await _repositoryManager.Role.GetSingleAsync(item => item.Id == id);
            var result = _mapper.Map<RoleModel>(role);

            return result;

        }
    }
}
