using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public TiposUsuarioDomain IdTipo { get; set; }
    }
}
