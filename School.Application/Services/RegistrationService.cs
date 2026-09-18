using School.Application.DTOs.Class;
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
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;
        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public async Task<RegistrationGetDTO> AddAsync(RegistrationPostDTO registrationPostDTO)
        {
            var registration = new Registration
            {
                UserId = registrationPostDTO.UserId,
                ClassId = registrationPostDTO.ClassId,
                DateRegistration = DateTime.UtcNow,
                DataExpiration = registrationPostDTO.DataExpiration,
                Active = true,
            };
            var createdRegistration = await _registrationRepository.AddAsync(registration);
            return new RegistrationGetDTO
            {
                Id = createdRegistration.Id,
                UserId = createdRegistration.UserId,
                ClassId = createdRegistration.ClassId,


                DateRegistration = createdRegistration.DateRegistration,
                DataExpiration = createdRegistration.DataExpiration,
                Active = createdRegistration.Active,
            };
        }
        public async Task<RegistrationGetDTO> DeleteAsync(int id)
        {
            var deletedRegistration = await _registrationRepository.DeleteAsync(id);
            if(deletedRegistration == null)
                return null;
            return new RegistrationGetDTO
            {
                Id = deletedRegistration.Id,
                UserId = deletedRegistration.UserId,
                ClassId = deletedRegistration.ClassId,
                DateRegistration = deletedRegistration.DateRegistration,
                DataExpiration = deletedRegistration.DataExpiration,
                Active = deletedRegistration.Active,
            };
        }
        public async Task<List<RegistrationGetDetailDTO>> GetAllAsync()
        {
            var registrations = await _registrationRepository.GetAllAsync();
            var registrationGetDetailDTO = new List<RegistrationGetDetailDTO>();
            registrationGetDetailDTO.AddRange(registrations.Select(registration => new RegistrationGetDetailDTO
            {
                Id = registration.Id,
                DateRegistration = registration.DateRegistration,
                DataExpiration = registration.DataExpiration,
                Active = registration.Active,
                User = new UserGetDTO
                {
                    Id = registration.User.Id,
                    Name = registration.User.Name,
                    Email = registration.User.Email,
                },
                Class = new ClassGetDTO
                {
                    Id = registration.Class.Id,
                    Name = registration.Class.Name,
                    Description = registration.Class.Description,
                }
            }));
            return registrationGetDetailDTO;
        }
        public async Task<RegistrationGetDetailDTO> GetByIdAsync(int id)
        {
            var registration = await _registrationRepository.GetByIdAsync(id);
            if (registration == null)
                return null;
            return new RegistrationGetDetailDTO
            {
                Id = registration.Id,
                DateRegistration = registration.DateRegistration,
                DataExpiration = registration.DataExpiration,
                Active = registration.Active,
                User = new UserGetDTO
                {
                    Id = registration.User.Id,
                    Name = registration.User.Name,
                    Email = registration.User.Email,
                },
                Class = new ClassGetDTO
                {
                    Id = registration.Class.Id,
                    Name = registration.Class.Name,
                    Description = registration.Class.Description,
                }
            };
        }
        public async Task<RegistrationGetDTO> UpdateAsync(RegistrationPutDTO registrationPutDTO)
        {
            var registration = new Registration
            {
                Id = registrationPutDTO.Id,
                ClassId = registrationPutDTO.ClassId,
                DataExpiration = registrationPutDTO.DataExpiration,
            };
            var updatedRegistration = await _registrationRepository.UpdateAsync(registration);
            if (updatedRegistration == null)
                return null;
            return new RegistrationGetDTO
            {
                Id = updatedRegistration.Id,
                UserId = updatedRegistration.UserId,
                ClassId = updatedRegistration.ClassId,
                DateRegistration = updatedRegistration.DateRegistration,
                DataExpiration = updatedRegistration.DataExpiration,
                Active = updatedRegistration.Active,
            };
        }
    }
}