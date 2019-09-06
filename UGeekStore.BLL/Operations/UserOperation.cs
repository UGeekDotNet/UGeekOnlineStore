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
    public class UserOperation : IUserOperation
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UserOperation(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<UserModel> AuthenticateAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = await _repositoryManager.Users.GetSingleAsync(x => x.UserName == username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            var result = _mapper.Map<UserModel>(user);

            return result;
        }

        public async Task<UserModel> GetUser(long id)
        {
            var user = await _repositoryManager.Users.GetSingleAsync(x => x.Id == id);
            var result = _mapper.Map<UserModel>(user);
            return result;
        }
        public async Task AddUser(UserModel user)
        {
            var result = _mapper.Map<User>(user);

            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

            result.PasswordSalt = passwordSalt;
            result.PasswordHash = passwordHash;

            _repositoryManager.Users.Add(result);
            await _repositoryManager.CompleteAsync();
        }
        public async Task UpdateUser(UserModel userModel)
        {
            var updateUser = _mapper.Map<User>(userModel);
            _repositoryManager.Users.Update(updateUser);
            await _repositoryManager.CompleteAsync();
        }
        public async Task DeleteUser(long id)
        {
            _repositoryManager.Users.DeleteWhere(x => x.Id == id);
            await _repositoryManager.CompleteAsync();
        }

        #region -- helper methods --

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        #endregion -- helper methods --

    }
}
