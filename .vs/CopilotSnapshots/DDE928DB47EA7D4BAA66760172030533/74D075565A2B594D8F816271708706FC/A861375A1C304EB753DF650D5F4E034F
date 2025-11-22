using EMMAData;
using EMMAModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EMMAData.Models;
using EMMA_Project.Extensions;
using System.Linq;

namespace EMMA_Project.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReadingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReadingController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/Reading?pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            pageNumber = Math.Max(1, pageNumber);
            pageSize = Math.Clamp(pageSize, 1, 100);

            var total = await _context.Readings.LongCountAsync();
            if (total == 0) return NoContent();

            var totalPages = (int)Math.Ceiling(total / (double)pageSize);

            var items = await _context.Readings
                .OrderBy(r => r.IdReading)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.Path}";
            var links = HateoasExtensions.BuildPagingLinks(baseUrl, pageNumber, pageSize, totalPages);

            var response = new PaginatedResponse<Reading>
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

        // GET: api/v1/Reading/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reading = await _context.Readings.FindAsync(id);
            if (reading == null) return NotFound(new { error = "Reading não encontrado." });

            var self = $"{Request.Scheme}://{Request.Host}{Request.Path}";
            return Ok(new { reading, Links = new Dictionary<string, string> { ["self"] = self } });
        }

        // POST: api/v1/Reading
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Reading reading)
        {
            if (reading == null || string.IsNullOrWhiteSpace(reading.Description) || string.IsNullOrWhiteSpace(reading.Humor))
                return BadRequest(new { error = "Dados inválidos." });

            reading.CreationDate = DateTime.UtcNow;
            _context.Readings.Add(reading);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = reading.IdReading }, reading);
        }

        // PUT: api/v1/Reading/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Reading reading)
        {
            if (reading == null || id != reading.IdReading)
                return BadRequest(new { error = "ID mismatch ou dados inválidos." });

            var existing = await _context.Readings.FindAsync(id);
            if (existing == null) return NotFound(new { error = "Reading não encontrado." });

            existing.Description = reading.Description;
            existing.Humor = reading.Humor;

            _context.Entry(existing).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/v1/Reading/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var reading = await _context.Readings.FindAsync(id);
            if (reading == null) return NotFound(new { error = "Reading não encontrado." });

            _context.Readings.Remove(reading);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
