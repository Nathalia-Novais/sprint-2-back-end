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
            throw new NotImplementedException();
        }

        public AluguelDomain BuscarPorId(int idAluguel)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listaAlugueis= new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = @"SELECT IdAluguel,ISNULL(ALUGUEL.idVeiculo,0),ISNULL(ALUGUEL.idCliente,0),dataAluguel , dataDevolucao, placaVeiculo,nomeCliente  FROM ALUGUEL
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
                                nomeCliente = rdr[6].ToString()
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
