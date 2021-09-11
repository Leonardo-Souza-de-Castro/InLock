using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {

        private string stringConexao = "Data Source=DESKTOP-9F56DG6\\SQLEXPRESS; initial catalog=Inlock_Games_Manha; integrated security=true;";

        //private string stringConexao = "Data Source=DESKTOP-R3SNJAL\\SQLEXPRESS; initial catalog=Inlock_Games_Manha; user id=sa; pwd=senai@132";

        public void AtualizarIdUrl(TiposUsuarioDomain TipoAtualizado, int IdTipo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "Update TiposUsuario Set Titulo = @Titulo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", TipoAtualizado.Titulo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public TiposUsuarioDomain BuscarporId(int Id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectbyId = "Select Titulo From TiposUsuario as TU where TU.IdTipo = @id";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectbyId, con))
                {
                    cmd.Parameters.AddWithValue("@id", Id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        TiposUsuarioDomain TipoUsuariobuscado = new TiposUsuarioDomain()
                        {
                            Titulo = rdr[0].ToString()
                        };

                        return TipoUsuariobuscado;
                    }
                    return null;

                }
            }
        }

        public void Cadastrar(TiposUsuarioDomain TipoNovo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "Insert Into TiposUsuario(Titulo) Values(@Titulo)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", TipoNovo.Titulo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdTipo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "Delete from TiposUsuario wher IdTipo = @Id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", IdTipo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TiposUsuarioDomain> Listar_Todos()
        {
            List<TiposUsuarioDomain> lista_tipos = new List<TiposUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "Select * From TiposUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TiposUsuarioDomain tipos = new TiposUsuarioDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[0]),
                            Titulo = rdr[1].ToString()
                        };

                        lista_tipos.Add(tipos);
                    }

                    return lista_tipos;
                }
            }
        }
    }
}
