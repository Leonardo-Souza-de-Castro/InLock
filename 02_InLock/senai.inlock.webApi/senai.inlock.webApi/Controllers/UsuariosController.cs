using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain Login)
        {
            UsuarioDomain UsuarioBuscado = _UsuarioRepository.BuscarporEmaileSenha(Login.email, Login.senha);

            if (UsuarioBuscado == null)
            {
                return NotFound(UsuarioBuscado);
            }

            var MinhasClaims = new[]
            {
                new Claim
            }
        }
    }
}
