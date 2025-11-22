using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EMMABusiness;
using EMMAModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EMMA_Project.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly PersonService _personService;
        private readonly ITokenService _tokenService;

        public AuthController(PersonService personService, ITokenService tokenService)
        {
            _personService = personService;
            _tokenService = tokenService;
        }

        // POST: api/v1/Auth/register
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] Person model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
                return BadRequest(new { error = "Email e senha são obrigatórios." });

            var existing = await _personService.GetByEmailAsync(model.Email);
            if (existing != null)
                return Conflict(new { error = "Usuário já existe com este e-mail." });

            var user = await _personService.CreateAsync(
                model.Name,
                model.Email,
                model.Password,
                model.Role ?? "User"
            );

            return CreatedAtAction(
                nameof(Me),
                routeValues: null,
                value: new
                {
                    message = "Usuário registrado com sucesso!",
                    user.IdPerson,
                    user.Name,
                    user.Email,
                    user.Role
                }
            );
        }

        // POST: api/v1/Auth/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest(new { error = "Email e senha são obrigatórios." });

            var user = await _personService.ValidateCredentialsAsync(request.Email, request.Password);
            if (user == null)
                return Unauthorized(new { error = "Credenciais inválidas." });

            var token = _tokenService.GenerateToken(
                user.IdPerson.ToString(),
                user.Email,
                user.Role ?? "User"
            );

            return Ok(token);
        }

        // GET: api/v1/Auth/me
        [HttpGet("me")]
        [Authorize]
        public IActionResult Me()
        {
            var email = User.Identity?.Name ?? "desconhecido";
            var role = User.FindFirst(ClaimTypes.Role)?.Value
                       ?? User.FindFirst("role")?.Value
                       ?? "Sem função";

            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                     ?? User.FindFirst("sub")?.Value;

            return Ok(new
            {
                Id = id,
                Email = email,
                Role = role
            });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
