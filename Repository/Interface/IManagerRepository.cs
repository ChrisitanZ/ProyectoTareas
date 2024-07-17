using Proyecto_de_Tareas.Properties.Model;

namespace Proyecto_de_Tareas.Repository.Interface;

public interface IManagerRepository
{
    Task<IEnumerable<Manager>> GetAllAsync();
    Task<Manager> GetByIdAsync(int id);
    Task AddAsync(Manager manager);
    Task UpdateAsync(Manager manager);
    Task DeleteAsync(int id);
    Task<Manager> GetByNameAsync(string nombre);
}