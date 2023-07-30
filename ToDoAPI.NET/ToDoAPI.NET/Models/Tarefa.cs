using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.NET.Models
{
    public class Tarefa
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Descricao { get; set; } = string.Empty;

        [Required]
        public DateTime DataInicio { get; set; }

        public StatusTarefa StatusTarefa { get; set; } = StatusTarefa.Backlog;
    }
}
