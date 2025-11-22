using Microsoft.AspNetCore.Mvc;
using EMMAData;
using EMMAModel;
using Microsoft.EntityFrameworkCore;

namespace EMMA_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonController(AppDbContext context)
        {
            _context = context;
        }

        // GET api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            return Ok(await _context.Persons.ToListAsync());
        }

        // GET api/Person/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null) return NotFound();

            return Ok(person);
        }

        // POST api/Person
        [HttpPost]
        public async Task<ActionResult<Person>> Create(Person p)
        {
            _context.Persons.Add(p);
            await _context.SaveChangesAsync();
            return Ok(p);
        }

        // PUT api/Person/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Person p)
        {
            var db = await _context.Persons.FindAsync(id);
            if (db == null) return NotFound();

            db.Name = p.Name;
            db.Email = p.Email;
            db.Password = p.Password;
            db.Role = p.Role;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/Person/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var db = await _context.Persons.FindAsync(id);
            if (db == null) return NotFound();

            _context.Persons.Remove(db);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
