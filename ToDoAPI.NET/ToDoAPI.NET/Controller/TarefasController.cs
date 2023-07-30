using Microsoft.AspNetCore.Mvc;
using ToDoAPI.NET.Models;
using ToDoAPI.NET.Services;

namespace ToDoAPI.NET.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _tarefa;

        public TarefasController(ITarefaService tarefa)
        {
            _tarefa = tarefa;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTodos()
        {
            var alunos = await _tarefa.GetTarefas();
            return Ok(alunos);
        }

        [HttpGet("{id:int}", Name = "GetTarefasPeloId")]
        public async Task<ActionResult<Tarefa>> GetTarefaPeloId(int? id)
        {
            var tarefa = await _tarefa.GetTarefaPeloId(id);

            if (tarefa == null)
            {
                return NotFound("Nenhuma tarefa encontrada");
            }
            else
            {
                return Ok(tarefa);
            }
        }

        [HttpGet("/StatusTarefa/{statusTarefa:int}")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefaPorStatus(StatusTarefa statusTarefa)
        {
            var tarefas = await _tarefa.GetTarefasPeloStatus(statusTarefa);

            if (tarefas == null)
                return NotFound();
            else
            {
                return Ok(tarefas);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Tarefa tarefa)
        {
            await _tarefa.Adicionar(tarefa);
            return CreatedAtRoute(nameof(GetTarefaPeloId), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromBody] Tarefa tarefa, int id)
        {
            if (tarefa.Id == id)
            {
                await _tarefa.Atualizar(tarefa);
                return Ok("Tarefa atualizada com sucesso.");
            }
            else
            {
                return BadRequest("Dados inconsisntentes.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var tarefa = await _tarefa.GetTarefaPeloId(id);

            if (tarefa != null)
            {
                await _tarefa.Deletar(tarefa);
                return Ok($"Aluno com o id = {id} deletado com sucesso");
            }
            else
            {
                return NotFound($"Tarefa com id = {id} não encontrada.");
            }
        }
    }
}
