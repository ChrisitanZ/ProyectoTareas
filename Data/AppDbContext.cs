using Microsoft.EntityFrameworkCore;
using Proyecto_de_Tareas.Properties.Model;

namespace Proyecto_de_Tareas.Data;

public class AppDbContext : DbContext
{
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Tarea> Tareas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    

    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Managers
        builder.Entity<Manager>().ToTable("Manager");
        builder.Entity<Manager>().HasKey(m => m.Id);
        builder.Entity<Manager>().Property(m => m.Nombre).IsRequired().HasMaxLength(100);
        builder.Entity<Manager>().Property(m => m.CorreoElectronico).IsRequired().HasMaxLength(100);
        builder.Entity<Manager>().Property(m => m.Contrasena).IsRequired().HasMaxLength(100);

        // Tareas
        // Tareas
        builder.Entity<Tarea>().ToTable("Tarea");
        builder.Entity<Tarea>().HasKey(t => t.Id);
        builder.Entity<Tarea>().Property(t => t.Titulo).IsRequired().HasMaxLength(200);
        builder.Entity<Tarea>().Property(t => t.Descripcion).IsRequired().HasMaxLength(1000);
        builder.Entity<Tarea>().Property(t => t.FechaLimite).IsRequired();
        builder.Entity<Tarea>().Property(t => t.UsuarioAsignadoId).IsRequired();
        builder.Entity<Tarea>().Property(t => t.Estado).IsRequired().HasConversion<string>(); 
        builder.Entity<Tarea>().Property(t => t.UsuarioCreadorId).IsRequired();
        builder.Entity<Tarea>().Property(t => t.ManagerCreadorId).IsRequired();
        
        
        
        builder.Entity<Tarea>()
            .Property(t => t.FechaCreacion)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Entity<Tarea>()
            .Property(t => t.FechaActualizacion)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate()
            .IsConcurrencyToken();
        // Relaciones de Tarea
        builder.Entity<Tarea>()
            .HasOne(t => t.UsuarioAsignado)
            .WithMany()
            .HasForeignKey(t => t.UsuarioAsignadoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Tarea>()
            .HasOne(t => t.UsuarioCreador)
            .WithMany()
            .HasForeignKey(t => t.UsuarioCreadorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Tarea>()
            .HasOne(t => t.ManagerCreador)
            .WithMany()
            .HasForeignKey(t => t.ManagerCreadorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Usuarios
        builder.Entity<Usuario>().ToTable("Usuario");
        builder.Entity<Usuario>().HasKey(u => u.Id);
        builder.Entity<Usuario>().Property(u => u.Nombre).IsRequired().HasMaxLength(100);
        builder.Entity<Usuario>().Property(u => u.CorreoElectronico).IsRequired().HasMaxLength(100);
        builder.Entity<Usuario>().Property(u => u.Contrasena).IsRequired().HasMaxLength(100);
    }
}
