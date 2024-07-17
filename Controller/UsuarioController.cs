using Microsoft.AspNetCore.Mvc;
using Proyecto_de_Tareas.DTO;
using Proyecto_de_Tareas.Services.Interface;

namespace Proyecto_de_Tareas.Controller;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(IUsuarioService usuarioService, ILogger<UsuarioController> logger)
    {
        _usuarioService = usuarioService;
        _logger = logger;
    }

    [HttpGet("usuarios")]
    public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ObtenerUsuarios()
    {
        var usuarios = await _usuarioService.GetAllUsuariosAsync();
        return Ok(usuarios);
    }

    // GET: api/Usuarios/5
    [HttpGet("usuarios/{id}")]
    public async Task<ActionResult<UsuarioDTO>> ObtenerUsuarioPorId(int id)
    {
        var usuario = await _usuarioService.GetUsuarioByIdAsync(id);

        if (usuario == null)
        {
            return NotFound();
        }

        return Ok(usuario);
    }

    // POST: api/Usuarios
    [HttpPost("usuarios")]
    public async Task<ActionResult<UsuarioDTO>> CrearUsuario(UsuarioDTO usuarioDto)
    {
        try
        {
            var nuevoUsuario = await _usuarioService.CreateUsuarioAsync(usuarioDto);
            return CreatedAtAction(nameof(ObtenerUsuarioPorId), new { id = nuevoUsuario.Id }, nuevoUsuario);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/Usuarios/5
    [HttpPut("usuarios/{id}")]
    public async Task<IActionResult> ActualizarUsuario(int id, UsuarioDTO usuarioDto)
    {
        try
        {
            await _usuarioService.UpdateUsuarioAsync(id, usuarioDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: api/Usuarios/5
    [HttpDelete("usuarios/{id}")]
    public async Task<IActionResult> EliminarUsuario(int id)
    {
        try
        {
            await _usuarioService.DeleteUsuarioAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

