using AutoMapper;
using Proyecto_de_Tareas.DTO;
using Proyecto_de_Tareas.Properties.Model;
using Proyecto_de_Tareas.Repository.Interface;
using Proyecto_de_Tareas.Services.Interface;

namespace Proyecto_de_Tareas.Services;

public class TareaService : ITareaService
{
    private readonly ITareaRepository _tareaRepository;
    private readonly IMapper _mapper;

    public TareaService(ITareaRepository tareaRepository, IMapper mapper)
    {
        _tareaRepository = tareaRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TareaDTO>> GetAllTareasAsync()
    {
        var tareas = await _tareaRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<TareaDTO>>(tareas);
    }

    public async Task<TareaDTO> GetTareaByIdAsync(int id)
    {
        var tarea = await _tareaRepository.GetByIdAsync(id);
        return _mapper.Map<TareaDTO>(tarea);
    }

    public async Task<TareaDTO> CreateTareaAsync(TareaDTO tareaDTO)
    {
        var tarea = _mapper.Map<Tarea>(tareaDTO);
        await _tareaRepository.AddAsync(tarea);
        return _mapper.Map<TareaDTO>(tarea);
    }

    public async Task UpdateTareaAsync(int id, TareaDTO tareaDTO)
    {
        var existingTarea = await _tareaRepository.GetByIdAsync(id);
        
        if (existingTarea == null)
        {
            // Manejo de error o excepción
            return;
        }

        _mapper.Map(tareaDTO, existingTarea);
        await _tareaRepository.UpdateAsync(existingTarea);
    }

    public async Task DeleteTareaAsync(int id)
    {
        await _tareaRepository.DeleteAsync(id);
    }
}
