using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using School.Domain.Account;
using School.Domain.Entities;
using School.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace School.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticateService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string GenerateToken(int id, string email, string role)
        {
            var claims = new[]
            {
                new Claim("id", id.ToString()),
                new Claim("email", email.ToLower()),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privatekey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(privatekey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Task<User> GetUserByIdEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
