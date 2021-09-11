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

        public string NomeJogo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataLancamento { get; set; }

        public decimal ValorJogo { get; set; }
        public EstudiosDomain Estudio { get; set; }
    }
}
