using School.Application.DTOs.Nota;
using School.Application.DTOs.User;
using School.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserGetDTO> GetByIdAsync(int id);
        Task<PagedList<UserGetDTO>> GetAllAsync(int pagenumber, int pagesize);
        Task<UserGetDTO> AddAsync(UserPostDTO userPostDTO);
        Task<UserGetDTO> UpdateAsync(int userId, UserPutDTO userPutDTO);
        Task<UserGetDTO> DeleteAsync(int id);
        Task<bool> ExistUserAsync();
    }
}