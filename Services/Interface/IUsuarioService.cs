using Proyecto_de_Tareas.DTO;

namespace Proyecto_de_Tareas.Services.Interface;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDTO>> GetAllUsuariosAsync();
    Task<UsuarioDTO> GetUsuarioByIdAsync(int id);
    Task<UsuarioDTO> CreateUsuarioAsync(UsuarioDTO usuarioDTO);
    Task UpdateUsuarioAsync(int id, UsuarioDTO usuarioDTO);
    Task DeleteUsuarioAsync(int id);
   
}