using ToDoAPI.NET.Models;

namespace ToDoAPI.NET.Services
{
    public interface ITarefaService
    {
        Task<IEnumerable<Tarefa>> GetTarefas();
        Task<IEnumerable<Tarefa>> GetTarefasPeloStatus(StatusTarefa statusTarefa);
        Task<Tarefa> GetTarefaPeloId(int? id);
        Task Adicionar(Tarefa tarefa);
        Task Atualizar(Tarefa tarefa);
        Task Deletar(Tarefa tarefa);
    }
}
