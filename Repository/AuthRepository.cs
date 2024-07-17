using Microsoft.EntityFrameworkCore;
using Proyecto_de_Tareas.Data;
using Proyecto_de_Tareas.Properties.Model;

namespace Proyecto_de_Tareas.Repository;

public class AuthRepository
{
    private readonly AppDbContext _context;

    public AuthRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Manager?> GetManagerByCredentialsAsync(string email, string password)
    {
        return await _context.Managers
            .FirstOrDefaultAsync(m => m.CorreoElectronico == email && m.Contrasena == password);
    }

    public async Task<Usuario?> GetUsuarioByCredentialsAsync(string email, string password)
    {
        return await _context.Usuarios
            .FirstOrDefaultAsync(u => u.CorreoElectronico == email && u.Contrasena == password);
    }
}