using Microsoft.EntityFrameworkCore;
using Proyecto_de_Tareas.Data;
using Proyecto_de_Tareas.Mapper;
using Proyecto_de_Tareas.Repository;
using Proyecto_de_Tareas.Repository.Interface;
using Proyecto_de_Tareas.Services;
using Proyecto_de_Tareas.Services.Interface;

var builder = WebApplication.CreateBuilder(args);


// Configuración de la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// Registrar servicios de aplicación y repositorios
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IManagerRepository, ManagerRepository>();
builder.Services.AddScoped<ITareaRepository, TareaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<ITareaService, TareaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<AuthRepository>();
builder.Services.AddScoped<AuthService>();

// Agregar controladores
builder.Services.AddControllers();

// Agregar autorización
builder.Services.AddAuthorization();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Proyecto Tareas API", Version = "v1" });
});

var app = builder.Build();

// Configurar middleware y enrutamiento
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Proyecto Tareas API V1");
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();