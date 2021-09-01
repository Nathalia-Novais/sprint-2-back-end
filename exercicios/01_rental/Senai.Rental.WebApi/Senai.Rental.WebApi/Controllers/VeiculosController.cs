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
    public class VeiculosController : ControllerBase
    {
        private IVeiculoRepository _veiculoRepository { get; set; }

        public VeiculosController()
        {
            _veiculoRepository = new VeiculoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> listaveiculos = _veiculoRepository.ListarTodos();

            return Ok(listaveiculos);

        }

        [HttpPost]
        public IActionResult Post(VeiculoDomain novoVeiculo)
        {

            _veiculoRepository.Cadastrar(novoVeiculo);

            return StatusCode(201);
        }
    }    
}
