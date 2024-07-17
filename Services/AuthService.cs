using Proyecto_de_Tareas.DTO;
using Proyecto_de_Tareas.Repository;

namespace Proyecto_de_Tareas.Services;

public class AuthService
{
    private readonly AuthRepository _authRepository;

    public AuthService(AuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<object> AuthenticateAsync(LoginDTO loginDTO)
    {
        // Verificar si es un Manager
        var manager = await _authRepository.GetManagerByCredentialsAsync(loginDTO.CorreoElectronico, loginDTO.Contrasena);
        if (manager != null)
        {
            // Retornar algún token o información del manager
            return new
            {
                Role = "Manager",
                Id = manager.Id,
                Nombre = manager.Nombre,
                // Otros datos necesarios
            };
        }

        // Verificar si es un Usuario
        var usuario = await _authRepository.GetUsuarioByCredentialsAsync(loginDTO.CorreoElectronico, loginDTO.Contrasena);
        if (usuario != null)
        {
            // Retornar algún token o información del usuario
            return new
            {
                Role = "Usuario",
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                // Otros datos necesarios
            };
        }

        // Si no se encuentra ni como Manager ni como Usuario
        return null;
    }
}