using Microsoft.EntityFrameworkCore;
using Proyecto_de_Tareas.Data;
using Proyecto_de_Tareas.Properties.Model;
using Proyecto_de_Tareas.Repository.Interface;

namespace Proyecto_de_Tareas.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuario> GetByIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task AddAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Usuario> AuthenticateAsync(string correoElectronico, string contrasena)
    {
        return await _context.Usuarios
            .FirstOrDefaultAsync(u => u.CorreoElectronico == correoElectronico && u.Contrasena == contrasena);
    }
}
