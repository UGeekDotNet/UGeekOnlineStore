using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using UGeekStore.Core.Infrastructre.BLLInterfaces;
using OnlineStore.Core.Models;
using OnlineStore.Core.Models.ViewModel;
using UGeekStore.Core.Models;

namespace OnlineStore.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsersAutentificationController : ControllerBase
    {
        private readonly IUserOperation _userOperation;
        private readonly TokenAuthentification _tokenAuthentication;
        private readonly IMapper _mapper;
        public UsersAutentificationController(IUserOperation userOperation, IOptions<TokenAuthentification> tokenAuthentication, IMapper mapper)
        {
            _userOperation = userOperation;
            _tokenAuthentication = tokenAuthentication.Value;
            _mapper = mapper;
        }


        // Login
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<UserAuthenticationModel> Authenticate([FromBody]LoginModel userModel)
        {
            var user = await _userOperation.AuthenticateAsync(userModel.Username, userModel.Password);

            if (user == null)
                throw new Exception("Username or password is incorrect");

            var userToken = GenerateUserToken(user);

            var result = new UserAuthenticationModel
            {
                Id = user.Id,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = userToken
            };

            return result;
        }
        #region -- helper functions --
        private string GenerateUserToken(UserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenAuthentication.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        #endregion
    }
}