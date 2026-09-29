using System.ComponentModel.DataAnnotations;

namespace School.API.Models
{
    public class PaginationParams
    {
        [Range(1, int.MaxValue, ErrorMessage = "A pagina deve ser maior que 1.")]
        public int PageNumber { get; set; }
        [Range(1, 50, ErrorMessage = "O tamanho da pagina deve ser maior que 1, e no maximo, 50 itens.")]
        public int PageSize { get; set; }
    }
}