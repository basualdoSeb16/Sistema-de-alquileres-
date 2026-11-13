
using System;
using System.Linq;
using Alquileres.Servidor.DTOs;
using Alquileres.Servidor.Repositories.Implementations;
using Alquileres.Servidor.Services.Implementations;
using Xunit;

namespace Alquileres.Tests.Integracion
{
    public class AlquilerIntegracionTests : IDisposable
    {
        private readonly PropiedadRepository propiedadRepository;
        private readonly PropiedadService propiedadService;
        private readonly AlquilerRepository alquilerRepository;
        private readonly AlquilerService alquilerService;

        public AlquilerIntegracionTests()
        {
            // Limpiamos los alquileres anteriores.
            alquilerRepository = new AlquilerRepository();
            LimpiarAlquileres();

            // Creamos los repositorios y servicios reales.
            propiedadRepository = new PropiedadRepository();

            propiedadService = new PropiedadService(
                propiedadRepository);

            alquilerService = new AlquilerService(
                alquilerRepository,
                propiedadService);
        }

        // CP-07: Registrar un alquiler y comprobar
        // que la propiedad cambie su estado.
        [Fact]
        public void CrearAlquiler_DebeActualizarEstadoDePropiedad()
        {
            // Arrange: utilizamos la propiedad inicial con ID 1.
            var propiedad = propiedadService.ObtenerPorId(1);

            Assert.NotNull(propiedad);
            Assert.Equal("Disponible", propiedad.Estado);

            var dto = new AlquilerCreateDto
            {
                PropiedadId = 1,
                Cliente = "Juan Perez",
                FechaInicio = new DateTime(2026, 11, 1),
                FechaFin = new DateTime(2026, 12, 1)
            };

            // Act: registramos el alquiler.
            var alquiler = alquilerService.Crear(dto);

            // Assert: comprobamos que se haya registrado.
            Assert.NotNull(alquiler);
            Assert.True(alquiler.Id > 0);

            var alquilerGuardado =
                alquilerRepository.ObtenerPorId(alquiler.Id);

            Assert.NotNull(alquilerGuardado);
            Assert.Equal(1, alquilerGuardado.PropiedadId);

            // Comprobamos que la propiedad cambió de estado.
            var propiedadActualizada =
                propiedadService.ObtenerPorId(1);

            Assert.NotNull(propiedadActualizada);
            Assert.Equal("Alquilada", propiedadActualizada.Estado);
        }

        // CP-08: No permitir otro alquiler sobre
        // una propiedad que ya fue alquilada.
        [Fact]
        public void CrearAlquiler_ConPropiedadYaAlquilada_DebeRechazarOperacion()
        {
            var dto = new AlquilerCreateDto
            {
                PropiedadId = 1,
                Cliente = "Juan Perez",
                FechaInicio = new DateTime(2026, 11, 1)
            };

            // Registramos el primer alquiler.
            alquilerService.Crear(dto);

            // Intentamos registrar otro alquiler
            // sobre la misma propiedad.
            var segundoDto = new AlquilerCreateDto
            {
                PropiedadId = 1,
                Cliente = "Pedro Gomez",
                FechaInicio = new DateTime(2026, 11, 2)
            };

            Assert.Throws<InvalidOperationException>(
                () => alquilerService.Crear(segundoDto));

            // Comprobamos que solamente exista un alquiler.
            Assert.Single(alquilerRepository.ObtenerTodos());

            // La propiedad debe continuar alquilada.
            var propiedad =
                propiedadService.ObtenerPorId(1);

            Assert.NotNull(propiedad);
            Assert.Equal("Alquilada", propiedad.Estado);
        }

        // Limpia los datos compartidos del repositorio.
        private void LimpiarAlquileres()
        {
            var alquileres =
                alquilerRepository.ObtenerTodos().ToList();

            foreach (var alquiler in alquileres)
            {
                alquilerRepository.Eliminar(alquiler.Id);
            }
        }

        public void Dispose()
        {
            // Evitamos dejar datos de prueba guardados.
            LimpiarAlquileres();
        }
    }
}

