using AutoMapper;
using Proyecto_de_Tareas.DTO;
using Proyecto_de_Tareas.Properties.Model;
using Proyecto_de_Tareas.Repository.Interface;
using Proyecto_de_Tareas.Services.Interface;

namespace Proyecto_de_Tareas.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UsuarioDTO>> GetAllUsuariosAsync()
    {
        var usuarios = await _usuarioRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
    }

    public async Task<UsuarioDTO> GetUsuarioByIdAsync(int id)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id);
        return _mapper.Map<UsuarioDTO>(usuario);
    }

    public async Task<UsuarioDTO> CreateUsuarioAsync(UsuarioDTO usuarioDTO)
    {
        var usuario = _mapper.Map<Usuario>(usuarioDTO);
        await _usuarioRepository.AddAsync(usuario);
        return _mapper.Map<UsuarioDTO>(usuario);
    }

    public async Task UpdateUsuarioAsync(int id, UsuarioDTO usuarioDTO)
    {
        var existingUsuario = await _usuarioRepository.GetByIdAsync(id);
        
        if (existingUsuario == null)
        {
            // Manejo de error o excepción
            return;
        }

        _mapper.Map(usuarioDTO, existingUsuario);
        await _usuarioRepository.UpdateAsync(existingUsuario);
    }

    public async Task DeleteUsuarioAsync(int id)
    {
        await _usuarioRepository.DeleteAsync(id);
    }
    
}
