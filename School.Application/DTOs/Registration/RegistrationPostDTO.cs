using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace School.Application.DTOs.Registration
{
    public class RegistrationPostDTO
    {
        [Required(ErrorMessage = "O Usuário é obrigatório.")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "A Turma é obrigatório.")]
        public int ClassId { get; set; }
        [Required(ErrorMessage = "A Data de Expiração é obrigatória.")]
        public DateTime DataExpiration { get; set; }
    }
}