using School.Application.DTOs.Course;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Application.Interfaces
{
    public interface ICourseService
    {
        Task<CourseGetDTO> GetByIdAsync(int id);
        Task<List<CourseGetDTO>> GetAllAsync();
        Task<CourseGetDTO> AddAsync(CoursePostDTO coursePostDTO);
        Task<CourseGetDTO> UpdateAsync(CoursePutDTO coursePutDTO);
        Task<CourseGetDTO> DeleteAsync(int id);
    }
}