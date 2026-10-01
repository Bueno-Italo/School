using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using School.Domain.Interfaces;
using School.Domain.Pagination;
using School.Infra.Data.Context;
using School.Infra.Data.Helpers;
using School.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infra.Data.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly ApplicationDbContext _context;
        public NotaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Nota> AddAsync(Nota nota)
        {
            _context.Nota.Add(nota);
            await _context.SaveChangesAsync();
            return nota;
        }
        public async Task<Nota> DeleteAsync(int id)
        {
            var nota = await _context.Nota.Where(x => x.Excluded == false && x.Id == id).FirstOrDefaultAsync();
            if (nota == null)
            {
                return null;
            }

            nota.Excluded = true;
            _context.Nota.Update(nota);
            await _context.SaveChangesAsync();
            return nota;
        }

        public async Task<PagedList<Nota>> GetAllAsync(int pagenumber, int pagesize)
        {
            var query = _context.Nota.Include(x => x.Registration).Where(x => x.Excluded == false).AsNoTracking();
            return await PaginationHelper.CreateAsync(query, pagenumber, pagesize);
        }

        public async Task<Nota> GetByIdAsync(int id)
        {
            return await _context.Nota.Where(x => x.Excluded == false && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Nota>> GetNotasByClassUser(int idClass, int idUser)
        {
            return await _context.Nota.Where(x => x.Excluded == false && x.Registration.ClassId == idClass && x.Registration.UserId == idUser).ToListAsync();
        }

        public async Task<PagedList<Nota>> GetNotasByClassUser(int idClass, int idUser, int pagenumber, int pagesize)
        {
            var query = _context.Nota
                .Where(x => x.Excluded == false && x.Registration.ClassId == idClass && x.Registration.UserId == idUser)
                .AsNoTracking();
            return await PaginationHelper.CreateAsync(query, pagenumber, pagesize);
        }

        public async Task<Nota> UpdateAsync(Nota nota)
        {
            _context.Nota.Update(nota);
            await _context.SaveChangesAsync();
            return nota;
        }
    }
}