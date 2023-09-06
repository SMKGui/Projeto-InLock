using System.Data.SqlClient;
using senai.inlock.webApi.tarde.Domains;
using senai.inlock.webApi.tarde.Interfaces;

namespace senai.inlock.webApi.tarde.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly string StringConexao = "Data Source = DESKTOP-8UO2UT6; Initial Catalog=inlock_games_tarde; User ID=sa; Pwd=Senai@134;";
        public void Cadastrar(EstudioDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Estudio(Nome) VALUES(@Nome)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoEstudio.Nome);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> ListaEstudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT * FROM Estudio";

                con.Open();


                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        ListaEstudios.Add(estudio);
                    }
                    //Retorna a lista de filmes
                    return ListaEstudios;
                }

            }
        }
    }
}
