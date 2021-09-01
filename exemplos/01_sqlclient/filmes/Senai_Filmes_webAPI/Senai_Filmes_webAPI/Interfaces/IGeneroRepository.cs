using Senai_Filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_webAPI.Interfaces
{
    /// <summary>
    ///  Interface responsável pelo repositório GeneroRepository
    /// </summary>
    interface IGeneroRepository
    {
        //Estrutura dos métodos
        // TipoRetorno NomeMetodo (TipoParametro NomeParametro);
        // Ex: GeneroDomain Cadastrar(GeneroDomain novoGenero);


        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        List<GeneroDomain> ListarTodos();
        
        /// <summary>
        /// Busca um genéro através do seu id
        /// </summary>
        /// <param name="idGenero">id do gênero que será´buscado</param>
        /// <returns> Um gênero buscado </returns>
        GeneroDomain BuscarPorId(int idGenero);

        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero com os novos dados</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Atualiza um genero existente
        /// </summary>
        /// <param name="generoAtualizado">objeto generoAtualizado com os novos daddos atualizados</param>
        void AtualizarIdCorpo (GeneroDomain generoAtualizado);

        /// <summary>
        ///  Atualiza um genero existente
        /// </summary>
        /// <param name="idGenero"> id do genero que sera atualizado</param>
        /// <param name="generoAtualizado">objeto generoAtualizado com os nvos dados atualizados</param>
        void AtualizarIdUrl(int idGenero,GeneroDomain generoAtualizado);

        /// <summary>
        /// Deleta um genero existente
        /// </summary>
        /// <param name="idGenero">id do genero que sera deletado</param>
        void Deletar(int idGenero);
    }
}
