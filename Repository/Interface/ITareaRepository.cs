using Proyecto_de_Tareas.Properties.Model;

namespace Proyecto_de_Tareas.Repository.Interface;

public interface ITareaRepository
{
    Task<IEnumerable<Tarea>> GetAllAsync();
    Task<Tarea> GetByIdAsync(int id);
    Task AddAsync(Tarea curso);
    Task UpdateAsync(Tarea curso);
    Task DeleteAsync(int id);
}