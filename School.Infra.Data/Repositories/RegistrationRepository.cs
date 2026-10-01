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
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly ApplicationDbContext _context;
        public RegistrationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Registration> AddAsync(Registration registration)
        {
            _context.Registration.Add(registration);
            await _context.SaveChangesAsync();
            return registration;
        }
        public async Task<Registration> DeleteAsync(int id)
        {
            var registration = await _context.Registration.Where(x => x.Excluded == false && x.Id == id).FirstOrDefaultAsync();
            if (registration == null)
            {
                return null;
            }

            registration.Excluded = true;
            _context.Registration.Update(registration);
            await _context.SaveChangesAsync();
            return registration;
        }

        public async Task<PagedList<Registration>> GetAllAsync(int pagenumber, int pagesize)
        {
            var query = _context.Registration.Include(x => x.User).Include(x => x.Class).Where(x => x.Excluded == false).AsNoTracking();
            return await PaginationHelper.CreateAsync(query, pagenumber, pagesize);
        }

        public async Task<Registration> GetByIdAsync(int id)
        {
            return await _context.Registration.Where(x => x.Excluded == false && x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Registration> UpdateAsync(Registration registration)
        {
            _context.Registration.Update(registration);
            await _context.SaveChangesAsync();
            return registration;
        }
    }
}