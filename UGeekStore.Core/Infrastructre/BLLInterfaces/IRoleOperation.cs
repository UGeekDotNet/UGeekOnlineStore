using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Models;

namespace UGeekStore.Core.Infrastructre.BLLInterfaces
{
    public interface IRoleOperation
    {
        Task<RoleModel> GetRole(long id);
        Task AddRole(RoleModel role);
        Task UpdateRole(RoleModel roleModel);
        Task DeleteRole(long id);
    }
}
