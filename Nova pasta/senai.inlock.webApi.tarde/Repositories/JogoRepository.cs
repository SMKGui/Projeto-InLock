using System.Data.SqlClient;
using senai.inlock.webApi.tarde.Domains;
using senai.inlock.webApi.tarde.Interfaces;

namespace senai.inlock.webApi.tarde.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly string StringConexao = "Data Source = DESKTOP-8UO2UT6; Initial Catalog=inlock_games_tarde; User ID=sa; Pwd=Senai@134;";

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que sera executada
                string queryInsert = "INSERT INTO Jogo(Nome, Descricao, DataLancamento, Valor, IdEstudio) VALUES (@Nome, @Descricao, @DataLancamento, @Valor, @IdEstudio)";



                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> ListaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string querySelectAll = "SELECT Jogo.IdJogo, Jogo.IdEstudio, Jogo.Nome, Jogo.Descricao, Jogo.DataLancamento, Jogo.Valor FROM Jogo INNER JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio";

                con.Open();

                //Declara o SqlDataReader para percorrer (ler) a tabela no banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que será executada e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["Nome"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            //DataLancamento = rdr["DataLancamento"].DateTime(),
                            //Valor = rdr["Valor"].ToString(),

                            Estudio = new EstudioDomain()
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                                Nome = rdr["Nome"].ToString()
                            }
                        };
                        ListaJogos.Add(jogo);
                    }
                    //Retorna a lista de filmes
                    return ListaJogos;
                }
            }
    }

    
    }
}
