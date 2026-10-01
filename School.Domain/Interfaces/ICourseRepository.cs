using School.Domain.Entities;
using School.Domain.Pagination;

namespace School.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> GetByIdAsync(int id);
        Task<PagedList<Course>> GetAllAsync(int pageNumber, int pageSize);
        Task<Course> AddAsync(Course course);
        Task<Course> UpdateAsync(Course course);
        Task<Course> DeleteAsync(int id);
    }
}