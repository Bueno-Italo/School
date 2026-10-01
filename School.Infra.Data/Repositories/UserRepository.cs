using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using School.Domain.Interfaces;
using School.Domain.Pagination;
using School.Infra.Data.Context;
using School.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> AddAsync(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteAsync(int id)
        {
            var user = await _context.User.Where(x => x.Excluded == false && x.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }

            user.Excluded = true;
            _context.User.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> ExistUserAsync()
        {
            return await _context.User.AnyAsync(x => x.Excluded == false);
        }

        public async Task<PagedList<User>> GetAllAsync(int pagenumber, int pagesize)
        {
            var query = _context.User.Where(x => x.Excluded == false).AsNoTracking();
            var users = await query.Skip((pagenumber - 1) * pagesize).Take(pagesize).ToListAsync();
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pagesize);
            return new PagedList<User>(users, pagenumber, pagesize, totalCount);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.User.Where(x => x.Excluded == false && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> UpdateAsync(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}