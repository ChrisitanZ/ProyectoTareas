using AutoMapper;
using Proyecto_de_Tareas.DTO;
using Proyecto_de_Tareas.Properties.Model;
using Proyecto_de_Tareas.Repository.Interface;
using Proyecto_de_Tareas.Services.Interface;

namespace Proyecto_de_Tareas.Services;

public class ManagerService : IManagerService
{
    private readonly IManagerRepository _managerRepository;
    private readonly IMapper _mapper;

    public ManagerService(IManagerRepository managerRepository, IMapper mapper)
    {
        _managerRepository = managerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ManagerDTO>> GetAllManagersAsync()
    {
        var managers = await _managerRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ManagerDTO>>(managers);
    }

    public async Task<ManagerDTO> GetManagerByIdAsync(int id)
    {
        var manager = await _managerRepository.GetByIdAsync(id);
        return _mapper.Map<ManagerDTO>(manager);
    }

    public async Task<ManagerDTO> CreateManagerAsync(ManagerDTO managerDTO)
    {
        var manager = _mapper.Map<Manager>(managerDTO);
        await _managerRepository.AddAsync(manager);
        return _mapper.Map<ManagerDTO>(manager);
    }

    public async Task UpdateManagerAsync(int id, ManagerDTO managerDTO)
    {
        var existingManager = await _managerRepository.GetByIdAsync(id);
        
        if (existingManager == null)
        {
            // Manejo de error o excepción
            return;
        }

        _mapper.Map(managerDTO, existingManager);
        await _managerRepository.UpdateAsync(existingManager);
    }

    public async Task DeleteManagerAsync(int id)
    {
        await _managerRepository.DeleteAsync(id);
    }
}
