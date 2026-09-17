using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace School.Application.DTOs.Nota
{
    public class NotaPostDTO
    {
        [Required(ErrorMessage = "A Mtricula é obrigatória.")]
        public int RegistrationId { get; set; }
        [Required(ErrorMessage = "O valor da Nota é obrigatório.")]
        [Range(0, 100, ErrorMessage = "O valor da Nota deve estar entre 0 e 100.")]
        public int ValueNota { get; set; }
    }
}