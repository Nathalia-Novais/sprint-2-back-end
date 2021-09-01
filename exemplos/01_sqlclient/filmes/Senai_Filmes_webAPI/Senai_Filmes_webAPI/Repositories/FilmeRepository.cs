using Senai_Filmes_webAPI.Domains;
using Senai_Filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_webAPI.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string stringConexao = "Data Source=DESKTOP-2U1VKIV\\SQLEXPRESS; initial catalog=CATALOGO_T; user Id=sa; pwd=senai@132";
        public void AtualizarIdUrl(int idFilme, FilmeDomain filmeAtualizado)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int idFilme)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idfilme)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectAll = "SELECT idFilme,ISNULL(FILME.idGenero,0), tituloFilme, nomeGenero FROM FILME LEFT JOIN GENERO ON FILME.idGenero = GENERO.idGenero; ";
               
                con.Open();

               
                SqlDataReader rdr;

               
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                   
                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            idFilme = Convert.ToInt32(rdr[0]),
                            idGenero = Convert.ToInt32(rdr[1]),
                            tituloFilme = rdr[2].ToString(),
                            genero = new GeneroDomain()
                            {
                                idGenero = Convert.ToInt32(rdr[1]),
                                nomeGenero = rdr[3].ToString()
                            }
                        };

                        listaFilmes.Add(filme);
                    }
                }
            };
            return listaFilmes;
        }
    }
}

