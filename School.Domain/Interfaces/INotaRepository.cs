using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Interfaces
{
    public interface INotaRepository
    {
        Task<Registration> GetByIdAsync(int id);
        Task<Registration> GetAllAsync();
        Task<Registration> AddAsync(Nota nota);
        Task<Registration> UpdateAsync(Nota nota);
        Task<Registration> DeleteAsync(int id);
    }
}
