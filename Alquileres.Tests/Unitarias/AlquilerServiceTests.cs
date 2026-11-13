
using Alquileres.Servidor.DTOs;
using Alquileres.Servidor.Models;
using Alquileres.Servidor.Repositories.Interfaces;
using Alquileres.Servidor.Services.Implementations;
using Alquileres.Servidor.Services.Interfaces;
using Moq;
using Xunit;

namespace Alquileres.Tests.Unitarias
{
    public class AlquilerServiceTests
    {
        private readonly Mock<IAlquilerRepository> alquilerRepositoryMock;
        private readonly Mock<IPropiedadService> propiedadServiceMock;
        private readonly AlquilerService alquilerService;

        public AlquilerServiceTests()
        {
            alquilerRepositoryMock = new Mock<IAlquilerRepository>();
            propiedadServiceMock = new Mock<IPropiedadService>();

            alquilerService = new AlquilerService(
                alquilerRepositoryMock.Object,
                propiedadServiceMock.Object);
        }

        // Prepara una propiedad disponible para las pruebas.
        private void ConfigurarPropiedad(Propiedad propiedad)
        {
            propiedadServiceMock
                .Setup(p => p.ObtenerPorId(propiedad.Id))
                .Returns(propiedad);

            propiedadServiceMock
                .Setup(p => p.Modificar(
                    propiedad.Id,
                    It.IsAny<PropiedadUpdateDto>()))
                .Returns(propiedad);
        }

        // CP-01: Registrar un alquiler correctamente.
        [Fact]
        public void Crear_ConDatosValidos_RegistraAlquiler()
        {
            var propiedad = new Propiedad
            {
                Id = 1,
                Direccion = "Av. Belgrano 123",
                Tipo = "Casa",
                Estado = "Disponible",
                Precio = 350000
            };

            ConfigurarPropiedad(propiedad);

            alquilerRepositoryMock
                .Setup(r => r.Agregar(It.IsAny<ALquiler>()))
                .Returns((ALquiler a) => a);

            var dto = new AlquilerCreateDto
            {
                PropiedadId = 1,
                Cliente = "Juan Perez",
                FechaInicio = new DateTime(2026, 11, 1),
                FechaFin = new DateTime(2026, 12, 1)
            };

            var resultado = alquilerService.Crear(dto);

            Assert.NotNull(resultado);
            Assert.Equal("Juan Perez", resultado.Cliente);
            Assert.Equal(1, resultado.PropiedadId);

            alquilerRepositoryMock.Verify(
                r => r.Agregar(It.IsAny<ALquiler>()),
                Times.Once);

            propiedadServiceMock.Verify(
                p => p.Modificar(
                    1,
                    It.Is<PropiedadUpdateDto>(
                        d => d.Estado == "Alquilada")),
                Times.Once);
        }

        // CP-02: Rechazar un alquiler con cliente vacío.
        [Fact]
        public void Crear_ConClienteVacio_LanzaExcepcion()
        {
            var dto = new AlquilerCreateDto
            {
                PropiedadId = 1,
                Cliente = "",
                FechaInicio = new DateTime(2026, 11, 1)
            };

            Assert.Throws<ArgumentException>(
                () => alquilerService.Crear(dto));

            alquilerRepositoryMock.Verify(
                r => r.Agregar(It.IsAny<ALquiler>()),
                Times.Never);
        }

        // CP-03: Rechazar un alquiler si la propiedad no existe.
        [Fact]
        public void Crear_ConPropiedadInexistente_LanzaExcepcion()
        {
            propiedadServiceMock
                .Setup(p => p.ObtenerPorId(99))
                .Returns((Propiedad?)null);

            var dto = new AlquilerCreateDto
            {
                PropiedadId = 99,
                Cliente = "Juan Perez",
                FechaInicio = new DateTime(2026, 11, 1)
            };

            Assert.Throws<ArgumentException>(
                () => alquilerService.Crear(dto));

            alquilerRepositoryMock.Verify(
                r => r.Agregar(It.IsAny<ALquiler>()),
                Times.Never);
        }

        // CP-04: Rechazar un alquiler si la propiedad ya está alquilada.
        [Fact]
        public void Crear_ConPropiedadAlquilada_LanzaExcepcion()
        {
            var propiedad = new Propiedad
            {
                Id = 1,
                Direccion = "Av. Belgrano 123",
                Estado = "Alquilada"
            };

            ConfigurarPropiedad(propiedad);

            var dto = new AlquilerCreateDto
            {
                PropiedadId = 1,
                Cliente = "Juan Perez",
                FechaInicio = new DateTime(2026, 11, 1)
            };

            Assert.Throws<InvalidOperationException>(
                () => alquilerService.Crear(dto));

            alquilerRepositoryMock.Verify(
                r => r.Agregar(It.IsAny<ALquiler>()),
                Times.Never);
        }

        // CP-05: Rechazar un alquiler con fecha de inicio inválida.
        [Fact]
        public void Crear_ConFechaInicioInvalida_LanzaExcepcion()
        {
            var dto = new AlquilerCreateDto
            {
                PropiedadId = 1,
                Cliente = "Juan Perez",
                FechaInicio = default
            };

            Assert.Throws<ArgumentException>(
                () => alquilerService.Crear(dto));

            alquilerRepositoryMock.Verify(
                r => r.Agregar(It.IsAny<ALquiler>()),
                Times.Never);
        }

        // CP-06: Aceptar fechas de inicio y fin iguales.
        [Fact]
        public void Crear_ConFechasIguales_RegistraAlquiler()
        {
            var propiedad = new Propiedad
            {
                Id = 1,
                Estado = "Disponible"
            };

            ConfigurarPropiedad(propiedad);

            alquilerRepositoryMock
                .Setup(r => r.Agregar(It.IsAny<ALquiler>()))
                .Returns((ALquiler a) => a);

            var fecha = new DateTime(2026, 11, 1);

            var dto = new AlquilerCreateDto
            {
                PropiedadId = 1,
                Cliente = "Juan Perez",
                FechaInicio = fecha,
                FechaFin = fecha
            };

            var resultado = alquilerService.Crear(dto);

            Assert.NotNull(resultado);

            alquilerRepositoryMock.Verify(
                r => r.Agregar(It.IsAny<ALquiler>()),
                Times.Once);
        }
    }
}
