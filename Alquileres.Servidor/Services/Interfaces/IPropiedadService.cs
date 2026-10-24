using Alquileres.Servidor.DTOs;
using Alquileres.Servidor.Models;
namespace Alquileres.Servidor.Services.Interfaces
{
    public interface IPropiedadService
    {
        List<Propiedad> ObtenerTodos();
        Propiedad? ObtenerPorId(int id);
        Propiedad Crear(PropiedadCreateDto dto);
        Propiedad? Modificar(int id, PropiedadUpdateDto dto);
        bool Eliminar(int id);
    }
}
