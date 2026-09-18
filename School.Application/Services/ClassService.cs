using School.Application.DTOs.Class;
using School.Application.DTOs.Course;
using School.Application.Interfaces;
using School.Domain.Entities;
using School.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Application.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        public async Task<ClassGetDTO> AddAsync(ClassPostDTO classPostDTO)
        {
            var newClass = new Class
            {
            Name = classPostDTO.Name,
            Description = classPostDTO.Description,
            CourseId = classPostDTO.CourseId
            };
            var createdClass = await _classRepository.AddAsync(newClass);
            return new ClassGetDTO
            {
            Id = createdClass.Id,
            Name = createdClass.Name,
            Description = createdClass.Description,
            CourseId = createdClass.CourseId
            };
        }
        public async Task<ClassGetDTO> DeleteAsync(int id)
        {
            var deleteClass = await _classRepository.DeleteAsync(id);
            if (deleteClass == null)
                return null;
            return new ClassGetDTO
            {
                Id = deleteClass.Id,
                Name = deleteClass.Name,
                Description = deleteClass.Description,
                CourseId = deleteClass.CourseId
            };
        }
        public async Task<List<ClassGetDetailsDTO>> GetAllAsync()
        {
            var classes = await _classRepository.GetAllAsync();
            var classGetDetailsDTO = new List<ClassGetDetailsDTO>();
            classGetDetailsDTO.AddRange(classes.Select(c => new ClassGetDetailsDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Course = new CourseGetDTO
                {
                    Id = c.Course.Id,
                    Name = c.Course.Name,
                    Description = c.Course.Description
                }
            }));
            return classGetDetailsDTO;

        }
        public async Task<ClassGetDetailsDTO> GetByIdAsync(int id)
        {
            var newClass = await _classRepository.GetByIdAsync(id);
            if(newClass == null)
                return null;
            return new ClassGetDetailsDTO
            {
                Id = newClass.Id,
                Name = newClass.Name,
                Description = newClass.Description,
                Course = new CourseGetDTO
                {
                    Id = newClass.Course.Id,
                    Name = newClass.Course.Name,
                    Description = newClass.Course.Description
                }
            };
        }
        public async Task<ClassGetDTO> UpdateAsync(ClassPutDTO classPutDTO)
        {
            var newClass = new Class
            {
                Id = classPutDTO.Id,
                Name = classPutDTO.Name,
                Description = classPutDTO.Description,
                CourseId = classPutDTO.CourseId
            };
            var updatedClass = await _classRepository.UpdateAsync(newClass);
            if (updatedClass == null)
                return null;
            return new ClassGetDTO
            {
                Id = updatedClass.Id,
                Name = updatedClass.Name,
                Description = updatedClass.Description,
                CourseId = updatedClass.CourseId
            };
        }
    }
}