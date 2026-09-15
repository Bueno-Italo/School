using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<Registration> GetByIdAsync(int id);
        Task<Registration> GetAllAsync();
        Task<Registration> AddAsync(Registration registration);
        Task<Registration> UpdateAsync(Registration registration);
        Task<Registration> DeleteAsync(int id);
    }
}
