using Microsoft.EntityFrameworkCore;
using ToDoAPI.NET.Context;
using ToDoAPI.NET.Models;

namespace ToDoAPI.NET.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly AppDbContext _context;

        public TarefaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> GetTarefas()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task<Tarefa> GetTarefaPeloId(int? id)
        {
            return await _context.Tarefas.FindAsync(id) ?? throw new Exception();
        }

        public async Task<IEnumerable<Tarefa>> GetTarefasPeloStatus(StatusTarefa statusTarefa)
        {
            return await _context.Tarefas.Where(t => t.StatusTarefa == statusTarefa).ToListAsync();
        }

        public async Task Adicionar(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Tarefa tarefa)
        {
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
        }
    }
}
