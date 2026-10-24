using Alquileres.Servidor.DTOs;
using Alquileres.Servidor.Models;
using Alquileres.Servidor.Repositories.Interfaces;
using Alquileres.Servidor.Services.Interfaces;
using System;
using System.Collections.Generic;
namespace Alquileres.Servidor.Services.Implementations
{
    public class AlquilerService : IAlquilerService
    {
        private readonly IAlquilerRepository alquilerRepository;
        private readonly IPropiedadService propiedadService;

        public AlquilerService(
            IAlquilerRepository alquilerRepository,
            IPropiedadService propiedadService)
        {
            this.alquilerRepository = alquilerRepository;
            this.propiedadService = propiedadService;
        }

        public List<ALquiler> ObtenerTodos()
        {
            return alquilerRepository.ObtenerTodos();
        }

        public ALquiler? ObtenerPorId(int id)
        {
            return alquilerRepository.ObtenerPorId(id);
        }

        public ALquiler Crear(AlquilerCreateDto dto)
        {
            ValidarDatos(dto.Cliente, dto.FechaInicio, dto.FechaFin);

            var propiedad = propiedadService.ObtenerPorId(dto.PropiedadId);

            if (propiedad == null)
            {
                throw new ArgumentException("La propiedad no existe.");
            }

            if (propiedad.Estado != "Disponible")
            {
                throw new InvalidOperationException(
                    "La propiedad no está disponible.");
            }

            var alquiler = new ALquiler
            {
                PropiedadId = dto.PropiedadId,
                Cliente = dto.Cliente.Trim(),
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin
            };

            alquilerRepository.Agregar(alquiler);

            CambiarEstadoPropiedad(propiedad.Id, "Alquilada");

            return alquiler;
        }

        public ALquiler? Modificar(int id, AlquilerUpdateDto dto)
        {
            var alquilerExistente = alquilerRepository.ObtenerPorId(id);

            if (alquilerExistente == null)
            {
                return null;
            }

            ValidarDatos(dto.Cliente, dto.FechaInicio, dto.FechaFin);

            var propiedadNueva = propiedadService.ObtenerPorId(dto.PropiedadId);

            if (propiedadNueva == null)
            {
                throw new ArgumentException("La propiedad no existe.");
            }

            bool cambiaPropiedad =
                alquilerExistente.PropiedadId != dto.PropiedadId;

            if (cambiaPropiedad && propiedadNueva.Estado != "Disponible")
            {
                throw new InvalidOperationException(
                    "La nueva propiedad no está disponible.");
            }

            // Si cambia la propiedad, liberamos la anterior.
            if (cambiaPropiedad)
            {
                CambiarEstadoPropiedad(
                    alquilerExistente.PropiedadId, "Disponible");
            }

            // La propiedad asignada al alquiler queda alquilada.
            CambiarEstadoPropiedad(propiedadNueva.Id, "Alquilada");

            alquilerExistente.PropiedadId = dto.PropiedadId;
            alquilerExistente.Cliente = dto.Cliente.Trim();
            alquilerExistente.FechaInicio = dto.FechaInicio;
            alquilerExistente.FechaFin = dto.FechaFin;

            alquilerRepository.Actualizar(alquilerExistente);

            return alquilerExistente;
        }

        public bool Eliminar(int id)
        {
            var alquiler = alquilerRepository.ObtenerPorId(id);

            if (alquiler == null)
            {
                return false;
            }

            bool eliminado = alquilerRepository.Eliminar(id);

            if (eliminado)
            {
                // Al eliminar el alquiler, liberamos la propiedad.
                CambiarEstadoPropiedad(alquiler.PropiedadId, "Disponible");
            }

            return eliminado;
        }

        private void ValidarDatos(
            string cliente,
            DateTime fechaInicio,
            DateTime? fechaFin)
        {
            if (string.IsNullOrWhiteSpace(cliente))
            {
                throw new ArgumentException(
                    "El nombre del cliente es obligatorio.");
            }

            if (fechaInicio == default)
            {
                throw new ArgumentException(
                    "La fecha de inicio es obligatoria.");
            }

            if (fechaFin.HasValue && fechaFin.Value < fechaInicio)
            {
                throw new ArgumentException(
                    "La fecha de fin no puede ser anterior a la fecha de inicio.");
            }
        }

        private void CambiarEstadoPropiedad(int propiedadId, string estado)
        {
            var propiedad = propiedadService.ObtenerPorId(propiedadId);

            if (propiedad == null)
            {
                throw new ArgumentException("La propiedad no existe.");
            }

            var dto = new PropiedadUpdateDto
            {
                Direccion = propiedad.Direccion,
                Tipo = propiedad.Tipo,
                Habitaciones = propiedad.Habitaciones,
                Banios = propiedad.Banios,
                Precio = propiedad.Precio,
                Estado = estado
            };

            propiedadService.Modificar(propiedadId, dto);
        }

    }
}
