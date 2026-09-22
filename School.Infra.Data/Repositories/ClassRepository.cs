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
    public class ClassRepository : IClassRepository
    {
        private readonly ApplicationDbContext _context;
        public ClassRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Class> AddAsync(Class Classes)
        {
            _context.Class.Add(Classes);
            await _context.SaveChangesAsync();
            return Classes;
        }

        public async Task<Class> DeleteAsync(int id)
        {
            var classes = await _context.Class.Where(x => x.Excluded == false && x.Id == id).FirstOrDefaultAsync();
            if (classes == null)
            {
                return null;
            }

            classes.Excluded = true;
            _context.Class.Update(classes);
            await _context.SaveChangesAsync();
            return classes;
        }
        public async Task<List<Class>> GetAllAsync()
        {
            return await _context.Class.Include(x => x.Course).Where(x => x.Excluded == false).ToListAsync();
        }

        public async Task<Class> GetByIdAsync(int id)
        {
            return await _context.Class.Include(x => x.Course).Where(x => x.Excluded == false && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Class> UpdateAsync(Class Classes)
        {
            _context.Class.Update(Classes);
            await _context.SaveChangesAsync();
            return Classes;
        }
    }
}