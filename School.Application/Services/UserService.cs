using School.Application.DTOs.User;
using School.Application.Interfaces;
using School.Domain.Entities;
using School.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace School.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserGetDTO> AddAsync(UserPostDTO userPostDTO)
        {
            using var hmac = new HMACSHA512();
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userPostDTO.Password));
            byte[] passwordSalt = hmac.Key;

            var existingUser = await _userRepository.ExistUserAsync();

            var user = new User
            {
                Name = userPostDTO.Name,
                Email = userPostDTO.Email,
                Excluded = false,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Profile = existingUser ? "User" : "Administrator"
            };

            var createdUser = await _userRepository.AddAsync(user);
            return new UserGetDTO
            {
                Id = createdUser.Id,
                Name = createdUser.Name,
                Email = createdUser.Email,
                Profile = createdUser.Profile
            };
        }
        public async Task<UserGetDTO> DeleteAsync(int id)
        {
            var deletedUser = await _userRepository.DeleteAsync(id);
            if(deletedUser == null)
                return null;
            return new UserGetDTO
            {
                Id = deletedUser.Id,
                Name = deletedUser.Name,
                Email = deletedUser.Email,
                Profile = deletedUser.Profile
            };

        }

        public async Task<bool> ExistUserAsync()
        {
            return await _userRepository.ExistUserAsync();
        }

        public async Task<List<UserGetDTO>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var userDTOs = new List<UserGetDTO>();
            userDTOs.AddRange(users.Select(user => new UserGetDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
            }));
            return userDTOs;
        }
        public async Task<UserGetDTO> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if(user == null)
                return null;
            return new UserGetDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Profile = user.Profile
            };
        }
        public async Task<UserGetDTO> UpdateAsync(int userId, UserPutDTO userPutDTO)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if(user == null)
                return null;

            user.Name = userPutDTO.Name;
            user.Email = userPutDTO.Email;

            var updatedUser = await _userRepository.UpdateAsync(user);
            return new UserGetDTO
            {
                Id = updatedUser.Id,
                Name = updatedUser.Name,
                Email = updatedUser.Email,
                Profile = updatedUser.Profile
            };
        }
    }
}