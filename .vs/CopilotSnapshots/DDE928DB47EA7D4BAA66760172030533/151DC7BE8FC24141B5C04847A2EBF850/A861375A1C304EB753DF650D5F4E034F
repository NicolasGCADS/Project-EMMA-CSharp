using EMMABusiness;
using EMMAModel;
using Microsoft.AspNetCore.Mvc;

namespace EMMA_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReadingController : ControllerBase
    {
        private readonly ReadingService _readingService;

        public ReadingController(ReadingService readingService)
        {
            _readingService = readingService;
        }

        // GET: api/Reading
        [HttpGet]
        public IActionResult Get()
        {
            var readings = _readingService.ListarTodos();
            return readings.Count == 0 ? NoContent() : Ok(readings);
        }

        // GET: api/Reading/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var reading = _readingService.ObterPorId(id);
            return reading == null ? NotFound() : Ok(reading);
        }

        // POST: api/Reading
        [HttpPost]
        public IActionResult Post([FromBody] Reading newReading)
        {
            if (string.IsNullOrWhiteSpace(newReading.Description))
                return BadRequest("Description é obrigatório.");

            if (string.IsNullOrWhiteSpace(newReading.Humor))
                return BadRequest("Humor é obrigatório.");

            // Define automaticamente a data de criação
            newReading.CreationDate = DateTime.UtcNow;

            var created = _readingService.Criar(newReading);

            return CreatedAtAction(nameof(Get), new { id = created.IdReading }, created);
        }

        // PUT: api/Reading/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Reading readingAtualizado)
        {
            if (readingAtualizado == null || readingAtualizado.IdReading != id)
                return BadRequest("Dados inconsistentes.");

            var sucesso = _readingService.Atualizar(readingAtualizado);

            return sucesso ? NoContent() : NotFound();
        }

        // DELETE: api/Reading/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _readingService.Remover(id) ? NoContent() : NotFound();
        }
    }
}
