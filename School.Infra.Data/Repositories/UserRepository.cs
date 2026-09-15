using School.Domain.Entities;
using School.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<Registration> AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<Registration> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Registration> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Registration> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Registration> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
