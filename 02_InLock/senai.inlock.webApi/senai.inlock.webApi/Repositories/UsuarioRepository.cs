using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-R3SNJAL\\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=senai@132";

        public void AtualizarIdUrl(UsuarioDomain UsuarioAtualizado, int IdUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "Update Usuario Set email = @email, senha = @senha";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@email", UsuarioAtualizado.email);
                    cmd.Parameters.AddWithValue("@senha", UsuarioAtualizado.senha);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UsuarioDomain BuscarporEmaileSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryLogin = @"select  IdUsuario, email, senha, IdTipo
	                                   from Usuario
	                                   where email  = @email
	                                   and senha = @senha";

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuariobuscado = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),
                            email = rdr[1].ToString(),
                            senha = rdr[2].ToString(),
                            IdTipo = new TiposUsuarioDomain { IdTipo = Convert.ToInt32(rdr[3])}
                        };

                        return usuariobuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(UsuarioDomain UsuarioNovo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "Insert Into Jogos(email, senha, idtipo) Values(@email, @senha, @id)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@email", UsuarioNovo.email);
                    cmd.Parameters.AddWithValue("@senha", UsuarioNovo.senha);
                    cmd.Parameters.AddWithValue("@id", UsuarioNovo.IdTipo.IdTipo); //Definir no Banco o Valor padrão para comum (Default = 1)

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "Delete From Usuario where IdUsuario = @Id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", IdUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<UsuarioDomain> Listar_Todos()
        {
            List<UsuarioDomain> lista_usuarios = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "Select email, Titulo From Usuario As U Inner Join TiposUsuario As T On U.IdTipo = T.IdTipo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            email = rdr[0].ToString(),
                            IdTipo = new TiposUsuarioDomain { Titulo = rdr[1].ToString()}
                        };

                        lista_usuarios.Add(usuario);
                    }

                    return lista_usuarios;
                }
            }
        }
    }
}
