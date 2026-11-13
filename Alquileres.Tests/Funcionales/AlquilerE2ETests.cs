
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace Alquileres.Tests.Funcionales
{
    public class AlquilerE2ETests
    {
        [Fact]
        public async Task RegistrarAlquiler_DebeCambiarEstadoYRechazarUnSegundoAlquiler()
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7122/")
            };

            int alquilerId = 0;

            try
            {
                // 1. Consultar las propiedades.
                var respuestaPropiedades =
                    await client.GetAsync("api/Propiedad");

                Assert.Equal(
                    HttpStatusCode.OK,
                    respuestaPropiedades.StatusCode);

                var propiedades =
                    await respuestaPropiedades.Content
                        .ReadFromJsonAsync<JsonElement>();

                // 2. Buscar una propiedad disponible.
                int propiedadId = 0;

                foreach (var propiedad in propiedades.EnumerateArray())
                {
                    string estado = propiedad
                        .GetProperty("estado")
                        .GetString() ?? "";

                    if (estado.Equals(
                        "Disponible",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        propiedadId = propiedad
                            .GetProperty("id")
                            .GetInt32();

                        break;
                    }
                }

                Assert.True(
                    propiedadId > 0,
                    "No hay propiedades disponibles para realizar la prueba.");

                // 3. Registrar un alquiler.
                var nuevoAlquiler = new
                {
                    PropiedadId = propiedadId,
                    Cliente = "Cliente Prueba E2E",
                    FechaInicio = DateTime.Today.AddDays(1),
                    FechaFin = (DateTime?)null
                };

                var respuestaCrear = await client.PostAsJsonAsync(
                    "api/Alquiler",
                    nuevoAlquiler);

                Assert.Equal(
                    HttpStatusCode.Created,
                    respuestaCrear.StatusCode);

                var alquilerCreado =
                    await respuestaCrear.Content
                        .ReadFromJsonAsync<JsonElement>();

                alquilerId = alquilerCreado
                    .GetProperty("id")
                    .GetInt32();

                // 4. Consultar el alquiler registrado.
                var respuestaAlquiler = await client.GetAsync(
                    $"api/Alquiler/{alquilerId}");

                Assert.Equal(
                    HttpStatusCode.OK,
                    respuestaAlquiler.StatusCode);

                // 5. Consultar la propiedad y verificar su estado.
                var respuestaPropiedad = await client.GetAsync(
                    $"api/Propiedad/{propiedadId}");

                Assert.Equal(
                    HttpStatusCode.OK,
                    respuestaPropiedad.StatusCode);

                var propiedadActualizada =
                    await respuestaPropiedad.Content
                        .ReadFromJsonAsync<JsonElement>();

                string estadoActual =
                    propiedadActualizada
                        .GetProperty("estado")
                        .GetString() ?? "";

                Assert.Equal("Alquilada", estadoActual);

                // 6. Intentar alquilar nuevamente la misma propiedad.
                var segundoAlquiler = await client.PostAsJsonAsync(
                    "api/Alquiler",
                    nuevoAlquiler);

                Assert.Equal(
                    HttpStatusCode.BadRequest,
                    segundoAlquiler.StatusCode);
            }
            finally
            {
                // Limpiar el alquiler creado para dejar
                // la propiedad disponible nuevamente.
                if (alquilerId > 0)
                {
                    await client.DeleteAsync(
                        $"api/Alquiler/{alquilerId}");
                }
            }
        }
    }
}
