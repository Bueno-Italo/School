using School.Domain.Entities;
using School.Domain.Pagination;

namespace School.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<PagedList<User>> GetAllAsync(int pagenumber, int pagesize);
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<User> DeleteAsync(int id);
        Task<bool> ExistUserAsync();
    }
}