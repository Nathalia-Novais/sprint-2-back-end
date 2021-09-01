using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private string stringConexao = "Data Source=DESKTOP-2U1VKIV\\SQLEXPRESS; initial catalog=T_Rental_N; user Id=sa; pwd=senai@132";

        //private string stringConexao = "Data Source=; initial catalog=catalogo_tarde; integrated security=true";

        public void AtualizarIdUrl(int idCliente, ClienteDomain ClienteAtualizado)
        {
            throw new NotImplementedException();
        }

        public ClienteDomain BuscarPorId(int idCliente)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO CLIENTE (nomeCliente,sobrenomeCliente,cpfCliente) VALUES (@nomeCliente,@sobrenomeCliente,@cpfCliente)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", novoCliente.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@cpfCliente", novoCliente.cpfCliente);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idCliente)
        {
            throw new NotImplementedException();
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> listaClientes = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idCliente,nomeCliente, sobrenomeCliente,cpfCliente FROM CLIENTE";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                  
                          ClienteDomain cliente = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(rdr[0]),

                            nomeCliente = rdr[1].ToString(),

                            sobrenomeCliente = rdr[2].ToString(),

                            cpfCliente = rdr[3].ToString(),
                          };

                        listaClientes.Add(cliente);
                    }
                }
            }

            return listaClientes;
        }
    }
}
