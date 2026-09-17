using School.Domain.Entities;

namespace School.Domain.Interfaces
{
    public interface IClassRepository
    {
        Task<Class> GetByIdAsync(int id);
        Task<List<Class>> GetAllAsync();
        Task<Class> AddAsync(Class Classes);
        Task<Class> UpdateAsync(Class Classes);
        Task<Class> DeleteAsync(int id);
    }
}