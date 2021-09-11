using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogosRepository : IJogosRepository
    {

        private string stringConexao = "Data Source=DESKTOP-9F56DG6\\SQLEXPRESS; initial catalog=Inlock_Games_Manha; integrated security=true;";

        //private string stringConexao = "Data Source=DESKTOP-R3SNJAL\\SQLEXPRESS; initial catalog=Inlock_Games_Manha; user id=sa; pwd=senai@132";

        
        public void AtualizarIdUrl(JogosDomain JogoAtualizado, int IdJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "Update Jogos Set NomeJogo = @Nome, Descricao = @Descri, DataLancamento = @DL, ValorJogo = @Valor where IdJogo = @Id";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", JogoAtualizado.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descri", JogoAtualizado.Descricao);
                    cmd.Parameters.AddWithValue("@DL", Convert.ToDateTime(JogoAtualizado.DataLancamento));
                    cmd.Parameters.AddWithValue("@Valor", JogoAtualizado.ValorJogo);
                    cmd.Parameters.AddWithValue("@Id", IdJogo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogosDomain BuscarporId(int Id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectbyId = "Select NomeEstudio As [Nome do Estudio], IdJogo As [Id Jogo], NomeJogo As Nome, Descricao As [Descrição], DataLancamento As [Data de Lançamento], ValorJogo As Valor From Jogos As J Inner Join Estudios As E on J.IdEstudio = E.IdEstudio where J.IdJogo = @id";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectbyId, con))
                {
                    cmd.Parameters.AddWithValue("@id", Id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogosDomain jogobuscado = new JogosDomain()
                        {
                            Estudio = new EstudiosDomain() { NomeEstudio = rdr[0].ToString() },
                            IdJogo = Convert.ToInt32(rdr[1]),
                            NomeJogo = rdr[2].ToString(),
                            Descricao = rdr[3].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr[4]),
                            ValorJogo = Convert.ToDecimal(rdr[5])
                        };

                        return jogobuscado;
                    }
                    return null;
                    
                }
            }
        }

        public void Cadastrar(JogosDomain JogoNovo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "Insert Into Jogos(NomeJogo, Descricao, DataLancamento, ValorJogo, IdEstudio) Values(@Nome, @Descri, @DL, @Valor, @Estudio)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", JogoNovo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descri", JogoNovo.Descricao);
                    cmd.Parameters.AddWithValue("@DL", JogoNovo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", JogoNovo.ValorJogo);
                    cmd.Parameters.AddWithValue("@Estudio", JogoNovo.Estudio.IdEstudio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "Delete From Jogos where IdJogo = @Id";

                using (SqlCommand cmd = new SqlCommand(queryDelete,con))
                {
                    cmd.Parameters.AddWithValue("@Id", IdJogo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogosDomain> Listar_Todos()
        {
            List<JogosDomain> Lista_Jogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect =  "Select NomeEstudio As [Nome do Estudio], IdJogo As [Id Jogo], NomeJogo As Nome, Descricao As [Descrição], DataLancamento As [Data de Lançamento], ValorJogo As Valor From Jogos As J Inner Join Estudios As E on J.IdEstudio = E.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect,con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogosDomain jogo = new JogosDomain()
                        {
                            Estudio = new EstudiosDomain() { 
                            NomeEstudio = rdr[0].ToString()},
                            IdJogo = Convert.ToInt32(rdr[1]),
                            NomeJogo = rdr[2].ToString(),
                            Descricao = rdr[3].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr[4]),
                            ValorJogo = Convert.ToDecimal(rdr[5])
                        };

                        Lista_Jogos.Add(jogo);
                    }

                    return Lista_Jogos;
                }
            }
        }
    }
}
