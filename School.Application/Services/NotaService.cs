using School.Application.DTOs.Class;
using School.Application.DTOs.Nota;
using School.Application.DTOs.Registration;
using School.Application.DTOs.User;
using School.Application.Interfaces;
using School.Domain.Entities;
using School.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Application.Services
{
    public class NotaService : INotaService
    {
        private readonly INotaRepository _notaRepository;
        public NotaService(INotaRepository notaRepository)
        {
            _notaRepository = notaRepository;
        }
        public async Task<NotaGetDTO> AddAsync(NotaPostDTO notaPostDTO)
        {
            var nota = new Nota
            {
                RegistrationId = notaPostDTO.RegistrationId,
                ValueNota = notaPostDTO.ValueNota,
                Approved = notaPostDTO.ValueNota >= 60,
                invoiceDate = DateTime.Now
            };
            var createdNota = await _notaRepository.AddAsync(nota);
            return new NotaGetDTO
            {
                Id = createdNota.Id,
                RegistrationId = createdNota.RegistrationId,
                ValueNota = createdNota.ValueNota,
                Approved = createdNota.Approved,
                invoiceDate = createdNota.invoiceDate
            };
        }
        public async Task<NotaGetDTO> DeleteAsync(int id)
        {
            var deleteNota = await _notaRepository.DeleteAsync(id);
            if (deleteNota == null)
                return null;
            return new NotaGetDTO
            {
                Id = deleteNota.Id,
                RegistrationId = deleteNota.RegistrationId,
                ValueNota = deleteNota.ValueNota,
                Approved = deleteNota.Approved,
                invoiceDate = deleteNota.invoiceDate
            };
        }
        public async Task<List<NotaGetDTO>> GetAllAsync()
        {
            var notas = await _notaRepository.GetAllAsync();
            var notaDTOs = new List<NotaGetDTO>();
            foreach (var nota in notas)
            {
                notaDTOs.Add(new NotaGetDTO
                {
                    Id = nota.Id,
                    RegistrationId = nota.RegistrationId,
                    ValueNota = nota.ValueNota,
                    Approved = nota.Approved,
                    invoiceDate = nota.invoiceDate
                });
            }
            return notaDTOs;
        }
        public async Task<NotaGetDTO> GetByIdAsync(int id)
        {
            var nota = await _notaRepository.GetByIdAsync(id);
            if (nota == null)
                return null;
            return new NotaGetDTO
            {
                Id = nota.Id,
                RegistrationId = nota.RegistrationId,
                ValueNota = nota.ValueNota,
                Approved = nota.Approved,
                invoiceDate = nota.invoiceDate
            };
        }
        public async Task<NotaGetDTO> UpdateAsync(NotaPutDTO notaPutDTO)
        {
            var existingNota = await _notaRepository.GetByIdAsync(notaPutDTO.Id);
            if (existingNota == null)
                return null;
            existingNota.ValueNota = notaPutDTO.ValueNota;
            existingNota.Approved = notaPutDTO.ValueNota >= 60;
            var updatedNota = await _notaRepository.UpdateAsync(existingNota);
            return new NotaGetDTO
            {
                Id = updatedNota.Id,
                RegistrationId = updatedNota.RegistrationId,
                ValueNota = updatedNota.ValueNota,
                Approved = updatedNota.Approved,
                invoiceDate = updatedNota.invoiceDate
            };
        }
    }
}