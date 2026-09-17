using School.Application.DTOs.Course;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Application.DTOs.Class
{
    public class ClassGetDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CourseGetDTO Course { get; set; }
    }
}