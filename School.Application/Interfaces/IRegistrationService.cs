using School.Application.DTOs.Registration;
using School.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Application.Interfaces
{
    public interface IRegistrationService
    {
        Task<RegistrationGetDetailDTO> GetByIdAsync(int id);
        Task<PagedList<RegistrationGetDetailDTO>> GetAllAsync(int pagenumber, int pagesize);
        Task<RegistrationGetDTO> AddAsync(RegistrationPostDTO registrationPostDTO);
        Task<RegistrationGetDTO> UpdateAsync(RegistrationPutDTO registrationPutDTO);
        Task<RegistrationGetDTO> DeleteAsync(int id);
    }
}