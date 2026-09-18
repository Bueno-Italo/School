using School.Application.DTOs.Class;
using School.Application.DTOs.Nota;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Application.Interfaces
{
    public interface IClassService
    {
        Task<ClassGetDetailsDTO> GetByIdAsync(int id);
        Task<List<ClassGetDetailsDTO>> GetAllAsync();
        Task<ClassGetDTO> AddAsync(ClassPostDTO classPostDTO);
        Task<ClassGetDTO> UpdateAsync(ClassPutDTO classPutDTO);
        Task<ClassGetDTO> DeleteAsync(int id);
    }
}