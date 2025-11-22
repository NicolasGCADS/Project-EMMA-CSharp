using EMMAData;
using EMMAModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMMA_Project.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReviewController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/Review?pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            pageNumber = Math.Max(1, pageNumber);
            pageSize = Math.Clamp(pageSize, 1, 100);

            var total = await _context.Reviews.LongCountAsync();
            var totalPages = (int)Math.Ceiling(total / (double)pageSize);

            var items = await _context.Reviews
                .OrderBy(r => r.IdReading)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.Path}";
            var links = new Dictionary<string, string>
            {
                ["self"] = $"{baseUrl}?pageNumber={pageNumber}&pageSize={pageSize}",
                ["first"] = $"{baseUrl}?pageNumber=1&pageSize={pageSize}",
                ["last"] = $"{baseUrl}?pageNumber={totalPages}&pageSize={pageSize}"
            };
            if (pageNumber > 1) links["prev"] = $"{baseUrl}?pageNumber={pageNumber - 1}&pageSize={pageSize}";
            if (pageNumber < totalPages) links["next"] = $"{baseUrl}?pageNumber={pageNumber + 1}&pageSize={pageSize}";

            var response = new
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = total,
                TotalPages = totalPages,
                Links = links
            };

            return Ok(response);
        }

        // GET: api/v1/Review/{idReading}
        [HttpGet("{idReading}")]
        public async Task<IActionResult> GetById(int idReading)
        {
            var review = await _context.Reviews
                .FirstOrDefaultAsync(r => r.IdReading == idReading);

            if (review == null)
                return NotFound(new { error = "Review não encontrado." });

            var self = $"{Request.Scheme}://{Request.Host}{Request.Path}";
            return Ok(new { review, Links = new Dictionary<string, string> { ["self"] = self } });
        }

        // POST: api/v1/Review
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Review review)
        {
            if (review == null || string.IsNullOrWhiteSpace(review.Description))
                return BadRequest(new { error = "Dados inválidos." });

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { idReading = review.IdReading }, review);
        }

        // PUT: api/v1/Review/{idReading}
        [HttpPut("{idReading}")]
        public async Task<IActionResult> Update(int idReading, [FromBody] Review review)
        {
            if (idReading != review.IdReading)
                return BadRequest(new { error = "O ID da URL não corresponde ao ID do objeto." });

            var existing = await _context.Reviews
                .FirstOrDefaultAsync(r => r.IdReading == idReading);

            if (existing == null)
                return NotFound(new { error = "Review não encontrado." });

            existing.Description = review.Description;

            _context.Entry(existing).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(existing);
        }

        // DELETE: api/v1/Review/{idReading}
        [HttpDelete("{idReading}")]
        public async Task<IActionResult> Delete(int idReading)
        {
            var review = await _context.Reviews
                .FirstOrDefaultAsync(r => r.IdReading == idReading);

            if (review == null)
                return NotFound(new { error = "Review não encontrado." });

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
