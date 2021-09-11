using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Informe o email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha.")]
        public string Senha { get; set; }
        public TiposUsuarioDomain IdTipoUsuario { get; set; }
    }
}
