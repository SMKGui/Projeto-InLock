using System.Data.SqlClient;
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
       private IJogoRepository _jogoRepository {get;set;}

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }
    }
}
