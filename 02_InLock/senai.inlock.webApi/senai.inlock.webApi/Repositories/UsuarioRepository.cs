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

        private string stringConexao = "Data Source=DESKTOP-9F56DG6\\SQLEXPRESS; initial catalog=Inlock_Games_Manha; integrated security=true;";

        //private string stringConexao = "Data Source=DESKTOP-R3SNJAL\\SQLEXPRESS; initial catalog=Inlock_Games_Manha; user id=sa; pwd=senai@132";


        //public void AtualizarIdUrl(UsuarioDomain UsuarioAtualizado, int IdUsuario)
        //{
        //    using (SqlConnection con = new SqlConnection(stringConexao))
        //    {
        //        string queryUpdate = "Update Usuario Set Email = @Email, Senha = @Senha";

        //        con.Open();

        //        using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
        //        {
        //            cmd.Parameters.AddWithValue("@Email", UsuarioAtualizado.Email);
        //            cmd.Parameters.AddWithValue("@Senha", UsuarioAtualizado.Senha);

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

        public UsuarioDomain BuscarporEmaileSenha(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryLogin = @"select  IdUsuario, Email, Senha, IdTipoUsuario
	                                   from Usuarios
	                                   where Email  = @Email
	                                   and Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Senha", Senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuariobuscado = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),
                            Email = rdr[1].ToString(),
                            Senha = rdr[2].ToString(),
                            IdTipoUsuario = new TiposUsuariosDomain { IdTipoUsuario = Convert.ToInt32(rdr[3])}
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
                string queryInsert = "Insert Into Usuarios(Email, Senha, IdTipoUsuario) Values(@Email, @Senha, @IdTipoUsuario)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Email", UsuarioNovo.Email);
                    cmd.Parameters.AddWithValue("@Senha", UsuarioNovo.Senha);
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", UsuarioNovo.IdTipoUsuario.IdTipoUsuario); //Definir no Banco o Valor padrão para comum (Default = 1)

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "Delete From Usuarios where IdUsuario = @Id";

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
                string querySelect = "Select email, Titulo From Usuarios As U Inner Join TiposUsuarios As T On U.IdTipoUsuario = T.IdTipoUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            Email = rdr[0].ToString(),
                            IdTipoUsuario = new TiposUsuariosDomain { Titulo = rdr[1].ToString()}
                        };

                        lista_usuarios.Add(usuario);
                    }

                    return lista_usuarios;
                }
            }
        }
    }
}
