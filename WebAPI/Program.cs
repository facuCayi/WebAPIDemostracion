using Aplicacion.Services;
using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Infraestructura.Persistencia;
using Infraestructura.Persistencia.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Hace que la API escuche en localhost:5118
builder.WebHost.UseUrls("http://localhost:5118");

// Configurar el DbContext con Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

//Inyeccion de dependencias
builder.Services.AddScoped(typeof(IUsuarioService), typeof(UserService));
builder.Services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepositorio));

builder.Services.AddScoped(typeof(IPolizaService), typeof(PolizaService));
builder.Services.AddScoped(typeof(IPolizaRepository), typeof(PolizaRepositorio));

builder.Services.AddScoped(typeof(ITab_LocatService), typeof(Tab_LocatService));
builder.Services.AddScoped(typeof(ITab_LocatRepository), typeof(Tab_LocatRepositorio));

builder.Services.AddScoped(typeof(IAddressRepository), typeof(AddressRepositorio));
builder.Services.AddScoped(typeof(IAddressService), typeof(AddressService));

builder.Services.AddScoped(typeof(IClienteService), typeof(ClientService));
builder.Services.AddScoped(typeof(IClientesRepository),typeof(ClientRepositorio));

builder.Services.AddScoped(typeof(IMedioDePagoRepository), typeof(MedioDePagoRepositorio));
builder.Services.AddScoped(typeof(IMedioDePagoService), typeof(MedioDePagoService));   

builder.Services.AddScoped(typeof(IMotAnulPolService), typeof(MotAnulPolService));
builder.Services.AddScoped(typeof(IMotAnulPolRepository), typeof(MotAnulPolRepositorio));

builder.Services.AddScoped(typeof(IMotAnulRecService), typeof(MotAnulRecService));
builder.Services.AddScoped(typeof(IMotAnulRecRepository), typeof(MotAnulRecRepositorio));

builder.Services.AddScoped(typeof(IMunicipalityRepository), typeof(MunicipalityRepositorio));
builder.Services.AddScoped(typeof(IMunicipalityService), typeof(MunicipalityService));

builder.Services.AddScoped(typeof(INacionalidadService), typeof(NacionalidadService));
builder.Services.AddScoped(typeof(INacionalidadRepository), typeof(NacionalidadRepositorio));

builder.Services.AddScoped(typeof(IPolicyHistoryService), typeof(PolicyHistoryService));
builder.Services.AddScoped(typeof(IPolicyHistoryRepository), typeof(PolicyHistoryRepositorio));

builder.Services.AddScoped(typeof(IPremiumRepository), typeof(PremiumRepositorio));
builder.Services.AddScoped(typeof(IPremiumService), typeof(PremiumService));

builder.Services.AddScoped(typeof(IProductmasterRepository), typeof(ProductmasterRepositorio));
builder.Services.AddScoped(typeof(IProductmasterService), typeof(ProductmasterService));

builder.Services.AddScoped(typeof(IProvinceRepository), typeof(ProvinceRepositorio));
builder.Services.AddScoped(typeof(IProvinceService), typeof(ProvinceService));

builder.Services.AddScoped(typeof(IRamoComercialService), typeof(RamoComercialService));
builder.Services.AddScoped(typeof(IRamoComercialRepository), typeof(RamoComercialRepositorio));

builder.Services.AddScoped(typeof(ISexoRepository), typeof(SexoRepositorio));
builder.Services.AddScoped(typeof(ISexoService), typeof(SexoService));




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