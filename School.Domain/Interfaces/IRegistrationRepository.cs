using School.Domain.Entities;

namespace School.Domain.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<Registration> GetByIdAsync(int id);
        Task<List<Registration>> GetAllAsync();
        Task<Registration> AddAsync(Registration registration);
        Task<Registration> UpdateAsync(Registration registration);
        Task<Registration> DeleteAsync(int id);
    }
}