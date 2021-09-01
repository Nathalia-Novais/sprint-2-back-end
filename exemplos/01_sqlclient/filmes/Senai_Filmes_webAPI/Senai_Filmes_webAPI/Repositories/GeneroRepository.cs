using Senai_Filmes_webAPI.Domains;
using Senai_Filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_webAPI.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private string stringConexao = @"Data Source=DESKTOP-2U1VKIV\SQLEXPRESS; initial catalog=CATALOGO_T; user Id=sa; pwd=senai@132";

        //private string stringConexao = "Data Source=DESKTOP-2U1VKIV\SQLEXPRESS; initial catalog=catalogo_manha; integrated security=true";

        public void AtualizarIdCorpo(GeneroDomain generoAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int idGenero)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cadastro um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto nomeGenero com as informações que serão cadastradas.</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO GENERO (nomeGenero) VALUES (@nomeGenero)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeGenero", novoGenero.nomeGenero);


                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM GENERO WHERE idGenero = @idGenero";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idGenero", idGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            
            
            }
        }

        public List<GeneroDomain> ListarTodos()
        {
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            //Declara a SqlConnection con passando a string de conexao como Parametro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idGenero, nomeGenero FROM GENERO";

                //Abre a conexão com o banco de dados.
                con.Open();

                //Declarando  SqlDataReader rdr percorrer a tabela do nosso banco de dados.
                SqlDataReader rdr;

                //Declara o SqlCommand passando da query que será executada e a conexão com parametros.
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //executa a query e armeza os dados no rdr. 
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver registros para serem lidos no rdr, o laço se repete.
                    while (rdr.Read())
                    {
                        //instancia um objeto genero do tipo GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //atribui a propriedade idGenero o valor da primeira coluna do bando de dados.
                            idGenero = Convert.ToInt32(rdr[0]),

                            //atribui a propriedade  o valor da segunda coluna da tabela do banco de dados.
                            nomeGenero = rdr[1].ToString()
                        };

                        //adiciona o objeto genero criado a lista listaGeneros
                        listaGeneros.Add(genero);
                    }
                }
            }

            return listaGeneros;
        }
    }
}
