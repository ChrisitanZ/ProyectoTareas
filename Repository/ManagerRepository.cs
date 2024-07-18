using Microsoft.EntityFrameworkCore;
using Proyecto_de_Tareas.Data;
using Proyecto_de_Tareas.Properties.Model;
using Proyecto_de_Tareas.Repository.Interface;

namespace Proyecto_de_Tareas.Repository;

public class ManagerRepository : IManagerRepository
{
    private readonly AppDbContext _context;

    public ManagerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Manager>> GetAllAsync()
    {
        return await _context.Managers.ToListAsync();
    }

    public async Task<Manager> GetByIdAsync(int id)
    {
        return await _context.Managers.FindAsync(id);
    }

    public async Task AddAsync(Manager manager)
    {
        await _context.Managers.AddAsync(manager);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Manager manager)
    {
        _context.Managers.Update(manager);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var manager = await _context.Managers.FindAsync(id);
        if (manager != null)
        {
            _context.Managers.Remove(manager);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Manager> GetByNameAsync(string nombre)
    {
        return await _context.Managers.FirstOrDefaultAsync(m => m.Nombre == nombre);
    }
}
