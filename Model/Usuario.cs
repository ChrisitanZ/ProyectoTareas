namespace Proyecto_de_Tareas.Properties.Model;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty; // Valor predeterminado
    public string CorreoElectronico { get; set; } = string.Empty; // Valor predeterminado
    public string Contrasena { get; set; } = string.Empty; // Valor predeterminado
}