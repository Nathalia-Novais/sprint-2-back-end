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
    public class ClientesController : ControllerBase
    {
        private IClienteRepository _clienteRepository { get; set; }

        public ClientesController()
        {
            _clienteRepository = new ClienteRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ClienteDomain> listaClientes = _clienteRepository.ListarTodos();

            return Ok(listaClientes);

        }

        [HttpPost]
        public IActionResult Post(ClienteDomain novoCliente)
        {

            _clienteRepository.Cadastrar(novoCliente);

            return StatusCode(201);
        }
    }
}