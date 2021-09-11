using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class TiposUsuariosDomain
    {
        public int IdTipoUsuario { get; set; }

        public string Titulo { get; set; }
    }
}
