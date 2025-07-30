using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TarefaController : ControllerBase
{
    private readonly TarefaContext contexto;

    public TarefaController(TarefaContext contexto)
    {
        this.contexto = contexto;
    }

    [HttpGet("{id:long}")]
    public ActionResult<Tarefa> Get(long id)
    {
        var tarefa = contexto.Tarefas.Find(id);
        if (tarefa == null)
        {
            return NotFound();
        }
        return Ok(tarefa);
    }
}