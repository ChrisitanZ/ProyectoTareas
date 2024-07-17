using AutoMapper;
using Proyecto_de_Tareas.DTO;
using Proyecto_de_Tareas.Properties.Model;

namespace Proyecto_de_Tareas.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Manager, ManagerDTO>().ReverseMap();
        CreateMap<Tarea, TareaDTO>()
            .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado.ToString()))
            .ForMember(dest => dest.fechaCreacion, opt => opt.MapFrom(src => src.FechaCreacion))
            .ForMember(dest => dest.fechaActualizacion, opt => opt.MapFrom(src => src.FechaActualizacion))
            .ReverseMap()
            .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => Enum.Parse<EstadoTarea>(src.Estado)))
            .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.fechaCreacion ?? DateTime.Now))
            .ForMember(dest => dest.FechaActualizacion, opt => opt.MapFrom(src => src.fechaActualizacion ?? DateTime.Now));
        CreateMap<Usuario, UsuarioDTO>().ReverseMap();

        CreateMap<Login, LoginDTO>().ReverseMap();
    }
}