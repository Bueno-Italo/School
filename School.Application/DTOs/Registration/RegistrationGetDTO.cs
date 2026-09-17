using System;
using System.Collections.Generic;
using System.Text;

namespace School.Application.DTOs.Registration
{
    public class RegistrationGetDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public DateTime DateRegistration { get; set; }
        public DateTime DataExpiration { get; set; }
        public bool Active { get; set; }
    }
}