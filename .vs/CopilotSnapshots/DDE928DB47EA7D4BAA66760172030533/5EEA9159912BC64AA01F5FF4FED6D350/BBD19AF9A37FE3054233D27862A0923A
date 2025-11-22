using EMMAData;
using EMMAModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMMA_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReviewController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Review
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _context.Reviews.ToListAsync();
            return Ok(reviews);
        }

        // GET: api/Review/{idReading}
        [HttpGet("{idReading}")]
        public async Task<IActionResult> GetById(int idReading)
        {
            var review = await _context.Reviews
                .FirstOrDefaultAsync(r => r.IdReading == idReading);

            if (review == null)
                return NotFound("Review não encontrado.");

            return Ok(review);
        }

        // POST: api/Review
        [HttpPost]
        public async Task<IActionResult> Create(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { idReading = review.IdReading }, review);
        }

        // PUT: api/Review/{idReading}
        [HttpPut("{idReading}")]
        public async Task<IActionResult> Update(int idReading, Review review)
        {
            if (idReading != review.IdReading)
                return BadRequest("O ID da URL não corresponde ao ID do objeto.");

            var existing = await _context.Reviews
                .FirstOrDefaultAsync(r => r.IdReading == idReading);

            if (existing == null)
                return NotFound("Review não encontrado.");

            existing.Description = review.Description;

            _context.Entry(existing).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(existing);
        }

        // DELETE: api/Review/{idReading}
        [HttpDelete("{idReading}")]
        public async Task<IActionResult> Delete(int idReading)
        {
            var review = await _context.Reviews
                .FirstOrDefaultAsync(r => r.IdReading == idReading);

            if (review == null)
                return NotFound("Review não encontrado.");

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
