using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private string stringConexao = "Data Source=DESKTOP-2U1VKIV\\SQLEXPRESS; initial catalog=T_Rental_N; user Id=sa; pwd=senai@132";

        //private string stringConexao = "Data Source=; initial catalog=catalogo_tarde; integrated security=true";

        public void AtualizarIdUrl(int idAluguel, AluguelDomain AluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE ALUGUEL SET dataAluguel= @dataAluguel , dataDevolucao= @dataDevolucao WHERE idAluguel= @idAluguel";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@dataAluguel", AluguelAtualizado.dataAluguel);
                    cmd.Parameters.AddWithValue("@dataDevolucao", AluguelAtualizado.dataDevolucao);
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarPorId(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idAluguel,dataAluguel,dataDevolucao,nomeCliente,sobrenomeCliente,placaVeiculo FROM ALUGUEL LEFT JOIN VEICULO ON VEICULO.IdVeiculo = ALUGUEL.IdVeiculo LEFT JOIN CLIENTE ON CLIENTE.IdCliente = ALUGUEL.IdCliente WHERE idAluguel = @idAluguel";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                          AluguelDomain aluguelBuscado = new AluguelDomain
                        {
                              idAluguel = Convert.ToInt32(reader["idAluguel"]),

                              dataAluguel = Convert.ToDateTime(reader["dataAluguel"]),

                              dataDevolucao = Convert.ToDateTime(reader["dataDevolucao"]),

                              cliente = new ClienteDomain
                              {
                                  nomeCliente = reader["nomeCliente"].ToString(),
                                  sobrenomeCliente = reader["sobrenomeCliente"].ToString()
                              },

                              veiculo = new VeiculoDomain
                              {
                                  placaVeiculo = reader["placaVeiculo"].ToString()
                              }
                          };

                        return aluguelBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO ALUGUEL (idVeiculo,idCliente,dataAluguel,dataDevolucao) VALUES (@idVeiculo,@idCliente,@dataAluguel,@dataDevolucao)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", novoAluguel.idVeiculo);
                    cmd.Parameters.AddWithValue("@idCliente", novoAluguel.idCliente);
                    cmd.Parameters.AddWithValue("@dataAluguel", novoAluguel.dataAluguel);
                    cmd.Parameters.AddWithValue("@dataDevolucao", novoAluguel.dataDevolucao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM ALUGUEL WHERE idAluguel = @idAluguel";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listaAlugueis= new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = @"SELECT IdAluguel,ISNULL(ALUGUEL.idVeiculo,0),ISNULL(ALUGUEL.idCliente,0),dataAluguel , dataDevolucao, placaVeiculo,nomeCliente,sobrenomeCliente,cpfCliente  FROM ALUGUEL
                                          LEFT JOIN VEICULO ON VEICULO.IdVeiculo = ALUGUEL.IdVeiculo
                                          LEFT JOIN CLIENTE ON CLIENTE.IdCliente = ALUGUEL.IdCliente";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        AluguelDomain aluguel = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),

                            idVeiculo = Convert.ToInt32(rdr[1]),

                            idCliente = Convert.ToInt32(rdr[2]),

                            dataAluguel = Convert.ToDateTime(rdr[3]),

                            dataDevolucao = Convert.ToDateTime(rdr[4]),

                            veiculo = new VeiculoDomain()
                            {
                                idVeiculo = Convert.ToInt32(rdr[1]),
                                placaVeiculo = rdr[5].ToString()
 
                            },

                             cliente = new ClienteDomain()
                            {
                                idCliente = Convert.ToInt32(rdr[2]),
                                nomeCliente = rdr[6].ToString(),
                                sobrenomeCliente = rdr[7].ToString(),
                                cpfCliente = rdr[8].ToString()
                             }
                        };

                        listaAlugueis.Add(aluguel);
                    }
                }
            }

            return listaAlugueis;
        }
    }
}
