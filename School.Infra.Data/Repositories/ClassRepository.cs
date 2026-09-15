using School.Domain.Entities;
using School.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infra.Data.Repositories
{
    public class ClassRepository : IClassRepository
    {
        public Task<Registration> AddAsync(Class Classes)
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

        public Task<Registration> UpdateAsync(Class Classes)
        {
            throw new NotImplementedException();
        }
    }
}
