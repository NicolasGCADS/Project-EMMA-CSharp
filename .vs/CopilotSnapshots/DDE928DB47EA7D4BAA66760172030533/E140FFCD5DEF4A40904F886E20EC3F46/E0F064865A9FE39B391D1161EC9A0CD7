using EMMABusiness;
using EMMAModel;
using Microsoft.AspNetCore.Mvc;

namespace EMMA_Project.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var persons = _personService.ListAll();
            return persons.Count == 0 ? NoContent() : Ok(persons);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personService.GetById(id);
            return person == null ? NotFound() : Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null || string.IsNullOrWhiteSpace(person.Email))
                return BadRequest("Email é obrigatório.");

            var created = _personService.Create(person);
            return CreatedAtAction(nameof(Get), new { id = created.IdPerson }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Person person)
        {
            if (person == null || person.IdPerson != id)
                return BadRequest("Dados inconsistentes.");

            return _personService.Update(person) ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _personService.Delete(id) ? NoContent() : NotFound();
        }
    }
}
