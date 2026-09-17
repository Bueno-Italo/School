using System;
using System.Collections.Generic;
using System.Text;

namespace School.Application.DTOs.User
{
    public class UserGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}