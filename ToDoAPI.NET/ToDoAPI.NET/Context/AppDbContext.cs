using Microsoft.EntityFrameworkCore;
using ToDoAPI.NET.Models;

namespace ToDoAPI.NET.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
