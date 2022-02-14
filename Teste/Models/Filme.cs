using System.ComponentModel.DataAnnotations;

namespace Teste.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(30, ErrorMessage = "O título do filme deve conter entre 2 e 30 caracteres.")]
        [MinLength(2, ErrorMessage = "O título do filme deve conter entre 2 e 30 caracteres.")]
        public string Titulo { get; set; }
        public bool Disponivel { get; set; }

        public Filme()
        {
        }
        public Filme(string titulo)
        {
            Titulo = titulo;
            Disponivel = true;
        }
    }
}
