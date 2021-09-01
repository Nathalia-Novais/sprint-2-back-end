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


    //Define que a rota de uma requisição será no formato domino/api/nomeController.
    // ex: http://localhost:5000/api/generos
    [Route("api/[controller]")]
    
    [ApiController]
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Obejto _generoRepository que irá receber todos os metodos definidor na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }
        /// <summary>
        /// Instancia um objeto _generoRepository para que haja a referencia aos metodos no repositorio.
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }
        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros e um status code.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Criar uma lista nomeada listaGeneros para receber os dados.
            List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

            //Retorna o status code 200(OK) com a lista de gêneros no formato JSON
            return Ok(listaGeneros);

        }


        /// <summary>
        ///  Cadastra um novo gênero
        /// </summary>
        /// <returns>Um status code 201 - Created</returns>

        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            //Faz a chamada para o método .cadastrar
            _generoRepository.Cadastrar(novoGenero);

            //Retorna um status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// ex: http://localhost:5000/api/genero/excluir/10
        [HttpDelete("excluir/{id}")]

        public IActionResult Delete(int id)
        {
            _generoRepository.Deletar(id);
         
            return NoContent();
        }

    }
}
