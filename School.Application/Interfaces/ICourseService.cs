using School.Application.DTOs.Course;
using School.Domain.Entities;
using School.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Application.Interfaces
{
    public interface ICourseService
    {
        Task<CourseGetDTO> GetByIdAsync(int id);
        Task<PagedList<CourseGetDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<CourseGetDTO> AddAsync(CoursePostDTO coursePostDTO);
        Task<CourseGetDTO> UpdateAsync(CoursePutDTO coursePutDTO);
        Task<CourseGetDTO> DeleteAsync(int id);
    }
}