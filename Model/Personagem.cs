using System.ComponentModel.DataAnnotations;

namespace Xablau.Models
{
    public class Personagem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório!")]
        [MaxLength(30, ErrorMessage = "O tipo deve ter no máximo 30 caracteres!")]
        public string Tipo { get; set; }
        
    }
}