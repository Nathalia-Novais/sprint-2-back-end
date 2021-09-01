using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class AlugueisController : ControllerBase
    {
        private IAluguelRepository _aluguelRepository { get; set; }

        public AlugueisController()
        {
            _aluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<AluguelDomain> listaAlugueis = _aluguelRepository.ListarTodos();

            return Ok(listaAlugueis);

        }

        [HttpPost]
        public IActionResult Post(AluguelDomain novoAluguel)
        {

            _aluguelRepository.Cadastrar(novoAluguel);

            return StatusCode(201);
        }
    }

}
