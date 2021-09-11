using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class JogosDomain
    {
        public int IdJogo { get; set; }

        [Required(ErrorMessage = "O nome do jogo é obrigatório.")]
        public string NomeJogo { get; set; }

        [Required(ErrorMessage = "A descricao do jogo é obrigatória.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data de lancamento do jogo é obrigatória.")]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "O valor do jogo é obrigatório.")]
        public decimal ValorJogo { get; set; }
        public EstudiosDomain Estudio { get; set; }
    }
}
