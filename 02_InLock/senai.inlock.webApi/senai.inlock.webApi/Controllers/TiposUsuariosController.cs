using Microsoft.AspNetCore.Authorization;
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

    [Authorize(Roles = "1")]

    public class TiposUsuariosController : ControllerBase
    {
        private ITiposUsuarioRepository _TipoUsuarioRepository { get; set; }

        public TiposUsuariosController()
        {
            _TipoUsuarioRepository = new TiposUsuarioRepository();
        }

        //Listar Todos
        [HttpGet]
        public IActionResult Get()
        {
            List<TiposUsuariosDomain> ListaTiposUsuarios = _TipoUsuarioRepository.Listar_Todos();

            return Ok(ListaTiposUsuarios);
        }

        ////Listar por Id 
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            TiposUsuariosDomain TipoUsuarioBuscado = _TipoUsuarioRepository.BuscarporId(Id);

            if (TipoUsuarioBuscado == null)
            {
                return NotFound("Tipo de usuário não encontrado.");
            }

            return Ok(TipoUsuarioBuscado);
        }

        //Cadastrar
        [HttpPost]
        public IActionResult Post(TiposUsuariosDomain NovoTipoUsuario)
        {
            _TipoUsuarioRepository.Cadastrar(NovoTipoUsuario);

            return Ok();
        }

        //Atualizar (passando pela Url)
        [HttpPut("{Id}")]
        public IActionResult PutUrl(int Id, TiposUsuariosDomain TipoAtualizado)
        {
            TiposUsuariosDomain TipoUsuarioBuscado = _TipoUsuarioRepository.BuscarporId(Id);

            if (TipoUsuarioBuscado == null)
            {
                return NotFound("Nenhum tipo de usuario encontrado!");
            }

            try
            {
                _TipoUsuarioRepository.AtualizarIdUrl(TipoAtualizado, Id);
                return NoContent();
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }


        //Deletar
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _TipoUsuarioRepository.Deletar(Id);

            return Ok();
        }
    }
}
