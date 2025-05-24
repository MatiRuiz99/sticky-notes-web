using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Model.Context;
using Model.DTO;
using Model.Helper;
using Model.Model;
using Service.IServices;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly AppDBContext _context;
        private readonly AppSettings _appSettings;

        public UserService(AppDBContext dbContext, AppSettings appSettings)
        {
            _context = dbContext;
            _appSettings = appSettings;
        }

        public ResponseDTO Register(UserDTO user)
        {
            User? founduser = _context.Users.FirstOrDefault(x => x.Email == user.Email);
            if (founduser != null)
            {
                return new ResponseDTO { Success = false, Message = "Already in Use" };
            }
            var newuser = new User() { Email = user.Email, Password = user.Password };

            _context.Users.Add(newuser);
            _context.SaveChanges();

            return new ResponseDTO { Success = true, Message = "Account created" };
        }

        public ResponseDTO Login(UserDTO user)
        {
            User? founduser = _context.Users.FirstOrDefault(x =>
                x.Email == user.Email && x.Password == user.Password
            );
            if (founduser == null)
            {
                return new ResponseDTO { Success = false, Message = "incorrect login" };
            }
            return new ResponseDTO
            {
                Success = true,
                Message = "Login success",
                Token = GetToken(user),
            };
        }

        private string GetToken(UserDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[] { new Claim(ClaimTypes.NameIdentifier, user.Email) }
                ),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
