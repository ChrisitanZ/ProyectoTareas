namespace Proyecto_de_Tareas.Properties.Model;

public class Tarea
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty; // Valor predeterminado
    public string Descripcion { get; set; } = string.Empty;
    public DateTime FechaLimite { get; set; }
    public int UsuarioAsignadoId { get; set; }
    public EstadoTarea Estado { get; set; }
    public DateTime FechaCreacion { get; set; }
    public int UsuarioCreadorId { get; set; }
    public int ManagerCreadorId { get; set; }
    public DateTime FechaActualizacion { get; set; }
    
    
    public Usuario UsuarioAsignado { get; set; }
    public Usuario UsuarioCreador { get; set; }
    public Manager ManagerCreador { get; set; }
}