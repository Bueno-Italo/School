using School.Domain.Entities;
using School.Domain.Pagination;

namespace School.Domain.Interfaces
{
    public interface INotaRepository
    {
        Task<Nota> GetByIdAsync(int id);
        Task<PagedList<Nota>> GetAllAsync(int pagenumber, int pagesize);
        Task<Nota> AddAsync(Nota nota);
        Task<Nota> UpdateAsync(Nota nota);
        Task<Nota> DeleteAsync(int id);
        Task<PagedList<Nota>> GetNotasByClassUser(int idClass, int idUser, int pagenumber, int pagesize);
    }
}