using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class Nota
    {
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public int ValueNota { get; set; }
        public bool Approved { get; set; }
        public Registration Registration {  get; set; }
    }
}
