using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class EstudiosDomain
    {
        public int IdEstudio { get; set; }

        public string NomeEstudio { get; set; }
        public JogosDomain Jogos { get; set; }
    }
}
