using senai.inlock.webApi.tarde.Domains;

namespace senai.inlock.webApi.tarde.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Método para buscar usuário por email e senha
        /// </summary>
        /// <param name="email">email do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns></returns>
        UsuarioDomain Login(string email, string senha);
    }
}
