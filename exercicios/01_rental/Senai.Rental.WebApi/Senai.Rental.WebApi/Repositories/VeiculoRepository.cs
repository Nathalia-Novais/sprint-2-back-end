using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private string stringConexao = "Data Source=DESKTOP-2U1VKIV\\SQLEXPRESS; initial catalog=T_Rental_N; user Id=sa; pwd=senai@132";

       //private string stringConexao = "Data Source=; initial catalog=catalogo_tarde; integrated security=true";
        public void AtualizarIdUrl(int idVeiculo, VeiculoDomain VeiculoAtualizado)
        {
            throw new NotImplementedException();
        }

        public VeiculoDomain BuscarPorId(int idVeiculo)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO VEICULO (idEmpresa,idModelo,placaVeiculo) VALUES (@idEmpresa,@idModelo,@placaVeiculo)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {      
                    cmd.Parameters.AddWithValue("@idEmpresa", novoVeiculo.idEmpresa);
                    cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.idModelo);
                    cmd.Parameters.AddWithValue("@placaVeiculo", novoVeiculo.placaVeiculo);


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idVeiculo)
        {
            throw new NotImplementedException();
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> listaVeiculos = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = @"SELECT idVeiculo,ISNULL(VEICULO.idEmpresa,0),ISNULL(VEICULO.idModelo,0),placaVeiculo,nomeEmpresa,nomeModelo FROM VEICULO 
                                          INNER JOIN EMPRESA ON EMPRESA.idEmpresa = VEICULO.idEmpresa
                                          INNER JOIN MODELO  ON  MODELO.idModelo = VEICULO.idModelo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        VeiculoDomain veiculo = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),

                            idEmpresa = Convert.ToInt32(rdr[1]),

                            idModelo = Convert.ToInt32(rdr[2]),

                            placaVeiculo = rdr[3].ToString(),

                             empresa = new EmpresaDomain()
                            {
                                idEmpresa = Convert.ToInt32(rdr[1]),
                                nomeEmpresa = rdr[4].ToString()
                            },

                              modelo = new ModeloDomain()
                            {                                
                               idModelo = Convert.ToInt32(rdr[2]),
                               nomeModelo = rdr[5].ToString()
                            }
                        };

                        listaVeiculos.Add(veiculo);
                    }
                }
            }

            return listaVeiculos;
        }
    }
}
