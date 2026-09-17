using School.Application.DTOs.Class;
using School.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Application.DTOs.Registration
{
    public class RegistrationGetDetailDTO
    {
        public int Id { get; set; }
        public UserGetDTO User { get; set; }
        public ClassGetDTO Class { get; set; }
        public DateTime DateRegistration { get; set; }
        public DateTime DataExpiration { get; set; }
        public bool Active { get; set; }
    }
}