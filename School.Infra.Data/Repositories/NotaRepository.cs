using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using School.Domain.Interfaces;
using School.Infra.Data.Context;
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

        public async Task<List<Nota>> GetAllAsync()
        {
            return await _context.Nota.Where(x => x.Excluded == false).ToListAsync();
        }

        public async Task<Nota> GetByIdAsync(int id)
        {
            return await _context.Nota.Where(x => x.Excluded == false && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Nota> UpdateAsync(Nota nota)
        {
            _context.Nota.Update(nota);
            await _context.SaveChangesAsync();
            return nota;
        }
    }
}