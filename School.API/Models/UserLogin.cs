using System.ComponentModel.DataAnnotations;

namespace School.API.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(250, ErrorMessage = "O nome deve ter no máximo 250 caracteres.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [MaxLength(250, ErrorMessage = "O email deve ter no máximo 250 caracteres.")]
        [EmailAddress(ErrorMessage = "O email não é válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres.")]
        [MaxLength(250, ErrorMessage = "A senha deve ter no máximo 250 caracteres.")]
        public string Password { get; set; }
    }
}