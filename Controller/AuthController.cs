using Microsoft.AspNetCore.Mvc;
using Proyecto_de_Tareas.DTO;
using Proyecto_de_Tareas.Services;

namespace Proyecto_de_Tareas.Controller;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        var result = await _authService.AuthenticateAsync(loginDTO);

        if (result == null)
        {
            return Unauthorized("Correo electrónico o contraseña incorrectos.");
        }

        return Ok(result);
    }
}