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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            VeiculoDomain veiculoBuscado = _veiculoRepository.BuscarPorId(id);

            if (veiculoBuscado == null)
            {
                return NotFound("Nenhum veiculo encontrado");
            }

            return Ok(veiculoBuscado);
        }

        [HttpPost]
        public IActionResult Post(VeiculoDomain novoVeiculo)
        {

            _veiculoRepository.Cadastrar(novoVeiculo);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, VeiculoDomain VeiculoAtualizado)
        {
            VeiculoDomain veiculoBuscado = _veiculoRepository.BuscarPorId(id);

            if (veiculoBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Veiculo não encontrado!",
                            erro = true
                        }
                    );
            }

            try
            {
                _veiculoRepository.AtualizarIdUrl(id, VeiculoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _veiculoRepository.Deletar(id);

            return NoContent();
        }
    }    
}
