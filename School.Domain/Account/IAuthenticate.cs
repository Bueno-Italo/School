using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Domain.Account
{
    public interface IAuthenticate
    {
        public string GenerateToken(int id, string email, string role);
        Task<User> GetUserByIdEmail(string email);
        Task<bool> UserExists(string email);
        Task<bool> AuthenticateAsync(string email, string password);
    }
}