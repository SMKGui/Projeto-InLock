using senai.inlock.webApi.tarde.Domains;

namespace senai.inlock.webApi.tarde.Interfaces
{
    public interface IJogoRepository
    {
        void Cadastrar(JogoDomain novoJogo);

        List<JogoDomain> ListarTodos();
    }
}
