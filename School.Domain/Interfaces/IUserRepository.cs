using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<Registration> GetByIdAsync(int id);
        Task<Registration> GetAllAsync();
        Task<Registration> AddAsync(User user);
        Task<Registration> UpdateAsync(User user);
        Task<Registration> DeleteAsync(int id);
    }
}
