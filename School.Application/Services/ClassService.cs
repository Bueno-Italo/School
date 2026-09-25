using School.App.Exceptions;
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
        private readonly ICourseRepository _courseRepository;
        public ClassService(IClassRepository classRepository, ICourseRepository courseRepository)
        {
            _classRepository = classRepository;
            _courseRepository = courseRepository;
        }
        public async Task<ClassGetDTO> AddAsync(ClassPostDTO classPostDTO)
        {
            var course = await _courseRepository.GetByIdAsync(classPostDTO.CourseId);
            if (course == null)
            {
                throw new NotFoundException("Curso não encontrado.");
            }
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
                throw new NotFoundException("Turma não encontrada.");
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
            var newClass = await _classRepository.GetByIdAsync(classPutDTO.Id);
            if (newClass == null)
            {
                throw new NotFoundException("Turma não encontrada.");
            }
            var course = await _courseRepository.GetByIdAsync(classPutDTO.CourseId);
            if (course == null)
            {
                throw new NotFoundException("Curso não encontrado.");
            }
            
            newClass.Id = classPutDTO.Id;
            newClass.Name = classPutDTO.Name;
            newClass.Description = classPutDTO.Description;
            newClass.CourseId = classPutDTO.CourseId;

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