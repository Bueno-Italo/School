using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Application.DTOs.Course
{
    public class CourseGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}