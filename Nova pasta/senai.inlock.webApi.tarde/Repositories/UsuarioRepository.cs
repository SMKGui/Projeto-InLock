using System.Data.SqlClient;
using senai.inlock.webApi.tarde.Domains;
using senai.inlock.webApi.tarde.Interfaces;

namespace senai.inlock.webApi.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string StringConexao = "Data Source = DESKTOP-8UO2UT6; Initial Catalog=Inlock_Games_Tarde; User ID=sa; Pwd=Senai@134;";

        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT IdUsuario, IdTipoUsuario, Email, Senha FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                        };
                        return usuario;
                    }
                    return null;
                }
            }
        }
    }
}
