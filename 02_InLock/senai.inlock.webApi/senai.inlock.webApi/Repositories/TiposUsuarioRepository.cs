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

        public void AtualizarIdUrl(TiposUsuariosDomain TipoAtualizado, int IdTipo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "Update TiposUsuarios Set Titulo = @Titulo Where IdTipoUsuario = @Id ";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", TipoAtualizado.Titulo);
                    cmd.Parameters.AddWithValue("@Id", IdTipo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public TiposUsuariosDomain BuscarporId(int Id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectbyId = "Select Titulo From TiposUsuarios as TU where TU.IdTipoUsuario = @id";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectbyId, con))
                {
                    cmd.Parameters.AddWithValue("@id", Id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        TiposUsuariosDomain TipoUsuariobuscado = new TiposUsuariosDomain()
                        {
                            Titulo = rdr[0].ToString()
                        };

                        return TipoUsuariobuscado;
                    }
                    return null;

                }
            }
        }


        public void Cadastrar(TiposUsuariosDomain TipoNovo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "Insert Into TiposUsuarios (Titulo) Values (@Titulo)";

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
                string queryDelete = "Delete from TiposUsuarios Where IdTipoUsuario = @Id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", IdTipo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TiposUsuariosDomain> Listar_Todos()
        {
            List<TiposUsuariosDomain> lista_tipos = new List<TiposUsuariosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "Select IdTipoUsuario, Titulo From TiposUsuarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TiposUsuariosDomain tipos = new TiposUsuariosDomain()
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
