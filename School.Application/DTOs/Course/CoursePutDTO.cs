using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace School.Application.DTOs.Course
{
    public class CoursePutDTO
    {
        [Required(ErrorMessage = "O identificador do curso é obrigatório.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O campo Nome deve ter no máximo 50 caracteres.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [MaxLength(150, ErrorMessage = "O campo Descrição deve ter no máximo 150 caracteres.")]
        public string Description { get; set; }
    }
}
