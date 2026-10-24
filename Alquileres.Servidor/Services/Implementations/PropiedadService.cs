using Alquileres.Servidor.DTOs;
using Alquileres.Servidor.Models;
using Alquileres.Servidor.Repositories.Interfaces;
using Alquileres.Servidor.Services.Interfaces;
namespace Alquileres.Servidor.Services.Implementations
{
    public class PropiedadService : IPropiedadService
    {
        private readonly IPropiedadRepository repository;

        public PropiedadService(IPropiedadRepository repository)
        {
            this.repository = repository;
        }

        public List<Propiedad> ObtenerTodos()
        {
            return repository.ObtenerTodos();
        }

        public Propiedad? ObtenerPorId(int id)
        {
            return repository.ObtenerPorId(id);
        }

        public Propiedad Crear(PropiedadCreateDto dto)
        {
            Propiedad propiedad = new Propiedad
            {
                Direccion = dto.Direccion.Trim(),
                Tipo = dto.Tipo.Trim(),
                Habitaciones = dto.Habitaciones,
                Banios = dto.Banios,
                Precio = dto.Precio,
                Estado = "Disponible"
            };

            return repository.Agregar(propiedad);
        }

        public Propiedad? Modificar(
            int id, PropiedadUpdateDto dto)
        {
            Propiedad? existente = repository.ObtenerPorId(id);

            if (existente == null)
                return null;

            if (dto.Estado != "Disponible" &&
                dto.Estado != "Alquilada")
            {
                throw new ArgumentException(
                    "El estado debe ser Disponible o Alquilada.");
            }

            existente.Direccion = dto.Direccion.Trim();
            existente.Tipo = dto.Tipo.Trim();
            existente.Habitaciones = dto.Habitaciones;
            existente.Banios = dto.Banios;
            existente.Precio = dto.Precio;
            existente.Estado = dto.Estado;

            repository.Actualizar(existente);

            return existente;
        }

        public bool Eliminar(int id)
        {
            return repository.Eliminar(id);
        }
    }
}
