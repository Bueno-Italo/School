using School.Domain.Entities;
using School.Domain.Pagination;

namespace School.Domain.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<Registration> GetByIdAsync(int id);
        Task<PagedList<Registration>> GetAllAsync(int pagenumber, int pagesize);
        Task<Registration> AddAsync(Registration registration);
        Task<Registration> UpdateAsync(Registration registration);
        Task<Registration> DeleteAsync(int id);
    }
}