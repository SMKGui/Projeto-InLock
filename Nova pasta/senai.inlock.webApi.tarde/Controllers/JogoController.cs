using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.tarde.Domains;
using senai.inlock.webApi.tarde.Interfaces;
using senai.inlock.webApi.tarde.Repositories;

namespace senai.inlock.webApi.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                List<JogoDomain> listaJogos = _jogoRepository.ListarTodos();

                return Ok(listaJogos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "2")]
        public IActionResult Post(JogoDomain novoJogo)
        {
            try
            {
                _jogoRepository.Cadastrar(novoJogo);

                return Created("objeto criado", novoJogo);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);                 
            }
        }
    }
}
