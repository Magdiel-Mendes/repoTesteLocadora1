using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Teste.Models
{
    [Index(nameof(Cpf))]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(30, ErrorMessage = "O nome deve conter entre 2 e 30 caracteres.")]
        [MinLength(2, ErrorMessage = "O nome deve conter entre 2 e 30 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(11, ErrorMessage = "O CPF deve conter 11 dígitos.")]
        [MinLength(11, ErrorMessage = "O CPF deve conter 11 dígitos.")]
        public string Cpf { get; set; }

        public Cliente()
        {
        }

        public Cliente(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }
    }
}
