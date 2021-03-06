using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class EstudiosRepository : IEstudiosRepository
    {

       // private string stringConexao = "Data Source=DESKTOP-9F56DG6\\SQLEXPRESS; initial catalog=Inlock_Games_Manha; integrated security=true;";

        private string stringConexao = "Data Source=DESKTOP-R3SNJAL\\SQLEXPRESS; initial catalog=Inlock_Games_Manha; user id=sa; pwd=senai@132";

        public void AtualizarIdUrl(EstudiosDomain estudioatualizado, int IdEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "Update Estudios Set NomeEstudio = @Nome Where IdEstudio = @Id";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", estudioatualizado.NomeEstudio);

                    cmd.Parameters.AddWithValue("@Id", IdEstudio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public EstudiosDomain BuscarporId(int Id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectbyId = "Select NomeEstudio From Estudios Where IdEstudio = @Id";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectbyId, con))
                {
                    cmd.Parameters.AddWithValue("@id", Id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        EstudiosDomain EstudioBuscado = new EstudiosDomain()
                        {
                            NomeEstudio = rdr[0].ToString()
                        };

                        return EstudioBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(EstudiosDomain EstudioNovo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "Insert Into Estudios(NomeEstudio) Values(@Nome)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", EstudioNovo.NomeEstudio);

                    cmd.ExecuteNonQuery();
                }


            }
        }

        public void Deletar(int IdEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "Delete From Estudios where IdEstudio = @Id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", IdEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudiosDomain> Listar_Todos()
        {
            List<EstudiosDomain> Lista_Estudios = new List<EstudiosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = @"Select NomeEstudio As [Nome do Estudio], 
                    Coalesce (IdJogo, 0) As [Id Jogo], 
                    IsNull (NomeJogo, 'Nada lançado até o momento') As [Nome do Jogo], 
                    IsNull(Descricao, 'Nada lançado até o momento') As [Descrição], 
                    IsNull (DataLancamento, '11-09-2021') As [Data de Lançamento], 
                    IsNull(ValorJogo, 0.00) As Valor
                    From Estudios As E 
                    Left Join Jogos As J
                    On E.IdEstudio = J.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudiosDomain Estudio = new EstudiosDomain()
                        {
                            NomeEstudio = rdr[0].ToString(),
                            Jogos = new JogosDomain { IdJogo = Convert.ToInt32(rdr[1]), NomeJogo = rdr[2].ToString(), Descricao = rdr[3].ToString(), DataLancamento = Convert.ToDateTime(rdr[4]), ValorJogo = Convert.ToDecimal(rdr[5])}
                        };

                        Lista_Estudios.Add(Estudio);
                    }

                    return Lista_Estudios;
                }
            }
        }
    }
}
