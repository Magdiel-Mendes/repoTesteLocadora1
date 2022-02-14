using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

namespace Teste.Models
{
    public class Locacao
    {
        [Key]
        public int Id { get; set; }

        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Nenhum filme escolhido.")]    
        public int FilmeId { get; set; }

        [Required(ErrorMessage = "Data de devolução não informada.")]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Dataretorno { get; set; }

        public bool Devolucao { get; set; }
        public bool Multa { get; set; }

        public Locacao()
        {
        }
        public Locacao(int clienteId, int filmeId, DateTime dataRetorno)
        {
            ClienteId = clienteId;
            FilmeId = clienteId;
            Dataretorno = dataRetorno;
            Devolucao = false;
            Multa = false;
        }

    }
}
