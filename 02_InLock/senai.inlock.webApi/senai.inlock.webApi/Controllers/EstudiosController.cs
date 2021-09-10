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
    public class EstudiosController : ControllerBase
    {
        private IEstudiosRepository _EstudioRepository { get; set; }

        public EstudiosController()
        {
            _EstudioRepository = new EstudiosRepository();
        }

        //Listar Todos
        [Authorize(Roles = "Administrador,  Cliente")]
        [HttpGet]
        public IActionResult Get()
        {
            List<EstudiosDomain> ListaEstudios = _EstudioRepository.Listar_Todos();

            return Ok(ListaEstudios);
        }


        //Listar por Id 
        [Authorize(Roles = "Administrador")]
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            EstudiosDomain EstudioBuscado = _EstudioRepository.BuscarporId(Id);

            if (EstudioBuscado == null)
            {
                return NotFound("Nenhum estúdio encontrado");
            }

            return Ok(EstudioBuscado);
        }

        //Cadastrar
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(EstudiosDomain NovoEstudio)
        {
            _EstudioRepository.Cadastrar(NovoEstudio);

            return Ok();
        }

        //Atualizar (passando pela Url)
        [Authorize(Roles = "Administrador")]
        [HttpPut("{Id}")]
        public IActionResult PutUrl(int Id, EstudiosDomain EstudioAtualizado)
        {
            EstudiosDomain EstudioBuscado = _EstudioRepository.BuscarporId(Id);

            if (EstudioBuscado == null)
            {
                return NotFound("Nenhum estúdio encontrado!");
            }

            try
            {
                _EstudioRepository.AtualizarIdUrl(EstudioAtualizado, Id);
                return NoContent();
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }

        }

        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(int Id)
        {
            _EstudioRepository.Deletar(Id);

            return Ok();
        }
    }
}
