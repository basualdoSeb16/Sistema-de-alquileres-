using Alquileres.Servidor.Models;
namespace Alquileres.Servidor.Repositories.Interfaces
{
    public interface IPropiedadRepository
    {
        List<Propiedad> ObtenerTodos();
        Propiedad? ObtenerPorId(int id);
        Propiedad Agregar(Propiedad propiedad);
        bool Actualizar(Propiedad propiedad);
        bool Eliminar(int id);
    }
}
