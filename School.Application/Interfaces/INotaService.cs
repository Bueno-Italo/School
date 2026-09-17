using School.Application.DTOs.Nota;
using School.Application.DTOs.Registration;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Application.Interfaces
{
    public interface INotaService
    {
        Task<NotaGetDTO> GetByIdAsync(int id);
        Task<List<NotaGetDTO>> GetAllAsync();
        Task<NotaGetDTO> AddAsync(NotaPostDTO notaPostDTO);
        Task<NotaGetDTO> UpdateAsync(NotaPutDTO notaPutDTO);
        Task<NotaGetDTO> DeleteAsync(int id);
    }
}