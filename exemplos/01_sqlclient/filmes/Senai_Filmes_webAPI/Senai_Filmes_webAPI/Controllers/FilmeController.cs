using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_Filmes_webAPI.Domains;
using Senai_Filmes_webAPI.Interfaces;
using Senai_Filmes_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_webAPI.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }
        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();

            return Ok(listaFilmes);
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            //Faz a chamada para o metodo cadastrar
            _filmeRepository.Cadastrar(novoFilme);

            return StatusCode(201);
        }
    }
}