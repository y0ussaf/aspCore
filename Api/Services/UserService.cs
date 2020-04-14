using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Api.Models;

namespace Api.Services
{
   
        public interface IUserService
        {
            AuthenticationResponseModel Authenticate(string username, string password);
        }

        public class UserService : IUserService
        {
            // users hardcoded for simplicity, store in a db with hashed passwords in production applications
           

            private readonly IRepository _context;

            public UserService(IRepository context)
            {
                _context = context;
            }

            public AuthenticationResponseModel Authenticate(string username, string password)
            {
                var user = _context.Users.SingleOrDefault(x => x.Email == username && x.Password == password);

                // return null if user not found
                if (user == null)
                    return null;

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", user.userId.ToString())
                }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                return new AuthenticationResponseModel { 
                    Token = user.Token,
                    Name = user.Name
                };
            }

            
       }
    
}
