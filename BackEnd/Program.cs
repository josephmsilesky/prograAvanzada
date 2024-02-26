using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProyectoAvanzadaContext>();

#region DI
builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
builder.Services.AddScoped<IBitacoraDAL, BitacoraDALImpl>();
builder.Services.AddScoped<IBitacoraService, BitacoraService>();

builder.Services.AddScoped<ICarritoDAL, CarritoDALImpl>();
builder.Services.AddScoped<ICarritoService, CarritoService>();

builder.Services.AddScoped<ICategoriaDAL, CategoriaDALImpl>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddScoped<ICompraDAL, CompraDALImpl>();
builder.Services.AddScoped<ICompraService, CompraService>();

builder.Services.AddScoped<ICursoDAL, CursoDALImpl>();
builder.Services.AddScoped<ICursoService, CursoService>();

builder.Services.AddScoped<IRolDAL, RolDALImpl>();
builder.Services.AddScoped<IRolService, RolService>();

builder.Services.AddScoped<IUsuarioDAL, UsuarioDALImpl>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();





#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
