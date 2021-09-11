using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
            UsuarioDomain UsuarioBuscado = _UsuarioRepository.BuscarporEmaileSenha(Login.Email, Login.Senha);

            if (UsuarioBuscado != null)
            {

            var MinhasClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, UsuarioBuscado.IdTipoUsuario.IdTipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("jogos-inlock-chave-autenticar"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var meuToken = new JwtSecurityToken(issuer : "inlock.webApi",
                audience : "inlock.webApi",
                claims : MinhasClaims,
                expires : DateTime.Now.AddHours(5),
                signingCredentials : creds
                );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(meuToken)
            });

            }

            return NotFound("Email ou senha inválido");
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            List<UsuarioDomain> ListaUsuarios = _UsuarioRepository.Listar_Todos();

            return Ok(ListaUsuarios);
        }

        [HttpPost]
        public IActionResult Post(UsuarioDomain NovoUsuario)
        {
            _UsuarioRepository.Cadastrar(NovoUsuario);

            return Ok();
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _UsuarioRepository.Deletar(Id);

            return Ok();
        }

        //[Authorize(Roles = "1, 2")]
        //[HttpPut("{Id}")]
        //public IActionResult PutUrl(string Email, string Senha, UsuarioDomain UsuarioAtualizado)
        //{
        //    UsuarioDomain UsuarioBuscado = _UsuarioRepository.BuscarporEmaileSenha(Email, Senha);

        //    if (UsuarioBuscado == null)
        //    {
        //        return NotFound("Nenhum estúdio encontrado!");
        //    }

        //    try
        //    {
        //        _UsuarioRepository.AtualizarIdUrl(UsuarioAtualizado, Id);
        //        return NoContent();
        //    }
        //    catch (Exception Erro)
        //    {
        //        return BadRequest(Erro);
        //        throw;
        //    }

        //}
    }
}
