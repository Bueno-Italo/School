using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
        public ICollection<Registration> Registrations { get; set; }
        public Course Course { get; set; }
        public bool Excluded { get; set; }
    }
}