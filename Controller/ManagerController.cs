using Microsoft.AspNetCore.Mvc;
using Proyecto_de_Tareas.DTO;
using Proyecto_de_Tareas.Services.Interface;

namespace Proyecto_de_Tareas.Controller;

[ApiController]
[Route("api/[controller]")]
public class ManagerController : ControllerBase
{
    private readonly IManagerService _managerService;
    private readonly ILogger<ManagerController> _logger;

    public ManagerController(IManagerService managerService, ILogger<ManagerController> logger)
    {
        _managerService = managerService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ManagerDTO>>> GetAllManagers()
    {
        try
        {
            var managers = await _managerService.GetAllManagersAsync();
            return Ok(managers);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todos los managers");
            return StatusCode(500, "Error interno al obtener los managers");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ManagerDTO>> GetManagerById(int id)
    {
        try
        {
            var manager = await _managerService.GetManagerByIdAsync(id);
            if (manager == null)
                return NotFound();

            return Ok(manager);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al obtener el manager con ID: {id}");
            return StatusCode(500, $"Error interno al obtener el manager con ID: {id}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<ManagerDTO>> CreateManager([FromBody] ManagerDTO managerDTO)
    {
        try
        {
            var createdManager = await _managerService.CreateManagerAsync(managerDTO);
            return CreatedAtAction(nameof(GetManagerById), new { id = createdManager.Id }, createdManager);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear un nuevo manager");
            return StatusCode(500, "Error interno al crear un nuevo manager");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateManager(int id, [FromBody] ManagerDTO managerDTO)
    {
        try
        {
            await _managerService.UpdateManagerAsync(id, managerDTO);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al actualizar el manager con ID: {id}");
            return StatusCode(500, $"Error interno al actualizar el manager con ID: {id}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteManager(int id)
    {
        try
        {
            await _managerService.DeleteManagerAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al eliminar el manager con ID: {id}");
            return StatusCode(500, $"Error interno al eliminar el manager con ID: {id}");
        }
    }
}
