using School.Domain.Entities;
using School.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infra.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public Task<Course> AddAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<Course> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Course> UpdateAsync(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
