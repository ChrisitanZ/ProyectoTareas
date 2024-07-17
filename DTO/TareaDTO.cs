using Proyecto_de_Tareas.Properties.Model;

namespace Proyecto_de_Tareas.DTO;

public class TareaDTO
{ 
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; } 
    public DateTime FechaLimite { get; set; }
    public int UsuarioAsignadoId { get; set; }
    public string Estado { get; set; } 
    public DateTime? fechaCreacion { get; set; }
    public int UsuarioCreadorId { get; set; }
    public int ManagerCreadorId { get; set; }
    public DateTime? fechaActualizacion { get; set; }
}