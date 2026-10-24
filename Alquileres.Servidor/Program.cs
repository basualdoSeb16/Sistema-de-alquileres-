
using Alquileres.Servidor.Repositories.Interfaces;
using Alquileres.Servidor.Repositories.Implementations;
using Alquileres.Servidor.Services.Interfaces;
using Alquileres.Servidor.Services.Implementations;

// Crea el constructor de la aplicación y carga su configuración.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// Agrega Swagger para probar y documentar la API.
builder.Services.AddSwaggerGen();

//Dependencias de propiedades
builder.Services.AddSingleton<
    IPropiedadRepository, PropiedadRepository>();

builder.Services.AddScoped<
    IPropiedadService, PropiedadService>();

//Dependencias de alquileres
builder.Services.AddSingleton<IAlquilerRepository, AlquilerRepository>();

builder.Services.AddScoped<IAlquilerService, AlquilerService>();

// Construye la aplicación.
var app = builder.Build();

// Comprueba si la aplicación está en modo desarrollo.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 

    app.UseSwaggerUI();
}

// Redirige las peticiones HTTP hacia HTTPS.
app.UseHttpsRedirection();

// Activa la autorización.
app.UseAuthorization();

// Conecta las rutas de los controladores con la aplicación.
app.MapControllers();

// Inicia el servidor y queda esperando peticiones.
app.Run();
