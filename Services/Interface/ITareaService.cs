using Proyecto_de_Tareas.DTO;

namespace Proyecto_de_Tareas.Services.Interface;

public interface ITareaService
{
    Task<IEnumerable<TareaDTO>> GetAllTareasAsync();
    Task<TareaDTO> GetTareaByIdAsync(int id);
    Task<TareaDTO> CreateTareaAsync(TareaDTO tareaDTO);
    Task UpdateTareaAsync(int id, TareaDTO tareaDTO);
    Task DeleteTareaAsync(int id);
}