using senai.inlock.webApi.tarde.Domains;

namespace senai.inlock.webApi.tarde.Interfaces
{
    public interface IEstudioRepository
    {
        void Cadastrar(EstudioDomain novoEstudio);

        List<EstudioDomain> ListarTodos();
    }
}
