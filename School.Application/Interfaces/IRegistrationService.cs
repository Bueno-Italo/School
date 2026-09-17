using School.Application.DTOs.Registration;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Application.Interfaces
{
    public interface IRegistrationService
    {
        Task<RegistrationGetDetailDTO> GetByIdAsync(int id);
        Task<List<RegistrationGetDetailDTO>> GetAllAsync();
        Task<RegistrationGetDTO> AddAsync(RegistrationPostDTO registrationPostDTO);
        Task<RegistrationGetDTO> UpdateAsync(RegistrationPutDTO registrationPutDTO);
        Task<RegistrationGetDTO> DeleteAsync(int id);
    }
}