using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class Registration
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ClassID { get; set; }
        public DateTime DateRegistration { get; set; }
        public DateTime DataExpiration {  get; set; }
        public bool Active { get; set; }
        public ICollection<Nota> Notas { get; set; }
        public User User { get; set; }
        public Class Class { get; set; }
    }
}
