using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Interfaces
{
    public interface IClassRepository
    {
        Task<Registration> GetByIdAsync(int id);
        Task<Registration> GetAllAsync();
        Task<Registration> AddAsync(Class Classes);
        Task<Registration> UpdateAsync(Class Classes);
        Task<Registration> DeleteAsync(int id);
    }
}
