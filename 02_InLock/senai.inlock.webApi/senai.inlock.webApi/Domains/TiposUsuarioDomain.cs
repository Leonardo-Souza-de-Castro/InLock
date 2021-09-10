using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class TiposUsuarioDomain
    {
        public int IdTipo { get; set; }

        [Required(ErrorMessage = "O tipo de usuário é obrigatório.")]
        public string Titulo { get; set; }
    }
}
