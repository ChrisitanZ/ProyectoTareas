using Microsoft.AspNetCore.Mvc;
using Proyecto_de_Tareas.DTO;
using Proyecto_de_Tareas.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_de_Tareas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private readonly ITareaService _tareaService;

        public TareasController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }

        // GET: api/Tareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TareaDTO>>> ObtenerTareas()
        {
            var tareas = await _tareaService.GetAllTareasAsync();
            return Ok(tareas);
        }

        // GET: api/Tareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TareaDTO>> ObtenerTareaPorId(int id)
        {
            var tarea = await _tareaService.GetTareaByIdAsync(id);

            if (tarea == null)
            {
                return NotFound();
            }

            return Ok(tarea);
        }

        // POST: api/Tareas
        [HttpPost]
        public async Task<ActionResult<TareaDTO>> CrearTarea(TareaDTO tareaDto)
        {
            try
            {
                var nuevaTarea = await _tareaService.CreateTareaAsync(tareaDto);
                return CreatedAtAction(nameof(ObtenerTareaPorId), new { id = nuevaTarea.Id }, nuevaTarea);
            }
            catch (Exception ex)
            {
                return BadRequest(GetInnerExceptionMessage(ex));
            }
        }

        // PUT: api/Tareas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarTarea(int id, TareaDTO tareaDto)
        {
            try
            {
                await _tareaService.UpdateTareaAsync(id, tareaDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(GetInnerExceptionMessage(ex));
            }
        }

        // DELETE: api/Tareas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTarea(int id)
        {
            try
            {
                await _tareaService.DeleteTareaAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(GetInnerExceptionMessage(ex));
            }
        }

        private string GetInnerExceptionMessage(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return GetInnerExceptionMessage(ex.InnerException);
            }
            return ex.Message;
        }
    }
}
