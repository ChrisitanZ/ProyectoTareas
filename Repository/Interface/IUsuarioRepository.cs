using Proyecto_de_Tareas.Properties.Model;

namespace Proyecto_de_Tareas.Repository.Interface;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task<Usuario> GetByIdAsync(int id);
    Task AddAsync(Usuario usuario);
    Task UpdateAsync(Usuario usuario);
    Task DeleteAsync(int id);
}