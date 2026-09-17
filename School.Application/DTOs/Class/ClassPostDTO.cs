using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace School.Application.DTOs.Class
{
    public class ClassPostDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O campo nome deve ter no máximo 50 caracteres.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [MaxLength(150, ErrorMessage = "O campo descrição deve ter no máximo 150 caracteres.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "O Curso é obrigatório.")]
        public int CourseId { get; set; }
    }
}