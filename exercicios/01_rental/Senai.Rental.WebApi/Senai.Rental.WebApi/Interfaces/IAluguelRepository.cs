using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{    
     /// <summary>
     /// Interface responsável pelo repositório AluguelRepository
    /// </summary>   
    interface IAluguelRepository
    {
        /// <summary>
        ///  Lista todos os Aluguéis
        /// </summary>
        /// <returns>Uma lista de Aluguéis</returns>
        List<AluguelDomain> ListarTodos();


        /// <summary>
        ///  Busca um Aluguel através do seu id
        /// </summary>
        /// <param name="idAluguel">id do Aluguel que será buscado</param>
        /// <returns>Um Aluguel buscado</returns>
        AluguelDomain BuscarPorId(int idAluguel);


        /// <summary>
        /// Cadastra um novo Aluguel
        /// </summary>
        /// <param name="novoAluguel">Objeto novoAluguelcom os novos dados</param>
        void Cadastrar(AluguelDomain novoAluguel);


        /// <summary>
        /// Atualiza um Aluguel existente
        /// </summary>
        /// <param name="idVeiculo">id do Aluguel que será atualizado</param>
        /// <param name="VeiculoAtualizado">Objeto veiculoAtualizado com os novos dados atualizados</param>
        void AtualizarIdUrl(int idAluguel, AluguelDomain AluguelAtualizado);

        /// <summary>
        /// Deleta um Aluguel existente
        /// </summary>
        /// <param name="idAluguel">id do Aluguel que será deletado</param>
        void Deletar(int idAluguel);
    }
}
