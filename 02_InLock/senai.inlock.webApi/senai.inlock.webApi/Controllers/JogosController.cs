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

    public class JogosController : ControllerBase
    {
        private IJogosRepository _JogoRepository { get; set; }

        public JogosController()
        {
            _JogoRepository = new JogosRepository();
        }

        //Listar Todos
        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Get()
        {
            List<JogosDomain> ListaJogos = _JogoRepository.Listar_Todos();

            return Ok(ListaJogos);
        }

        //Buscar por Id
        [Authorize(Roles = "1, 2")]
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            JogosDomain JogoBuscado = _JogoRepository.BuscarporId(Id);

            if (JogoBuscado == null)
            {
                return NotFound("Nenhum jogo encontrado!");
            }

            return Ok(JogoBuscado);
        }

        //Cadastrar
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(JogosDomain NovoJogo)
        {
            _JogoRepository.Cadastrar(NovoJogo);

            return Ok();
        }

        //Atualizar (passando pela Url)
        [Authorize(Roles = "1")]
        [HttpPut("{Id}")]
        public IActionResult PutUrl(int Id, JogosDomain JogoAtualizado)
        {
            //JogosDomain JogoBuscado = _JogoRepository.BuscarporId(Id);

            JogosDomain JogoBuscado = _JogoRepository.BuscarporId(Id);

            if (JogoBuscado == null)
            {
                return NotFound("Nenhum jogo encontrado!");
            }

            try
            {
                _JogoRepository.AtualizarIdUrl(JogoAtualizado, Id);
                return NoContent();
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            //_JogoRepository.Deletar(Id);

            _JogoRepository.Deletar(Id);

            return Ok();
        }

    }

}
