using Senai_Filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_webAPI.Interfaces
{
    /// <summary>
    ///  Interface responsável pelo repositório FilmeRepository
    /// </summary>
    interface IFilmeRepository
    {
        /// <summary>
        /// Lista todos os Filmes
        /// </summary>
        /// <returns>Uma lista de filmes</returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Busca um filme através do seu id
        /// </summary>
        /// <param name="idFilme">id do filme que será buscado</param>
        /// <returns> Um filme buscado </returns>
        FilmeDomain BuscarPorId(int idFilme);

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto novoFilme com os novos dados</param>
        void Cadastrar(FilmeDomain novoFilme);


        /// <summary>
        ///  Atualiza um Filme existente
        /// </summary>
        /// <param name="idFilme"> id do filme que sera atualizado</param>
        /// <param name="filmeAtualizado">objeto filmeAtualizado com os nvos dados atualizados</param>
        void AtualizarIdUrl(int idFilme, FilmeDomain filmeAtualizado);

        /// <summary>
        /// Deleta um filme existente
        /// </summary>
        /// <param name="idfilme">id do filme que sera deletado</param>
        void Deletar(int idfilme);
    }
}
