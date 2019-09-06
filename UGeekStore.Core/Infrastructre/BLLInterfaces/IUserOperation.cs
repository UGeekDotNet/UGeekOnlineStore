using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Models;

namespace UGeekStore.Core.Infrastructre.BLLInterfaces
{
    public interface IUserOperation
    {
        Task<UserModel> AuthenticateAsync(string username, string password);
        Task<UserModel> GetUser(long id);
        Task AddUser(UserModel user);
        Task UpdateUser(UserModel userModel);
        Task DeleteUser(long id);
    }
}
