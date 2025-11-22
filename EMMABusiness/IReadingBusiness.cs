using EMMAModel;

namespace EMMABusiness
{
    public interface IReadingService
    {
        List<Reading> ListarTodos();
        Reading? ObterPorId(int id);
        Reading Criar(Reading reading);
        bool Atualizar(Reading reading);
        bool Remover(int id);
    }
}
