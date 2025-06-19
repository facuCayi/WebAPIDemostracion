using Microsoft.EntityFrameworkCore;
using Infraestructura.Persistencia;
using Aplicacion.Services;
using Dominio.Contracts.Servicios;
using Dominio.Contracts.Repositorios;
using Infraestructura.Persistencia.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Configurar el DbContext con Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

//Inyeccion de dependencias
builder.Services.AddScoped(typeof(IUsuarioService), typeof(UserService));
builder.Services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepositorio));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();