using Alquileres.Servidor.Models;
using System.Collections.Generic;
namespace Alquileres.Servidor.Repositories.Interfaces
{
    public interface IAlquilerRepository
    {
        List<ALquiler> ObtenerTodos();

        ALquiler? ObtenerPorId(int id);

        ALquiler Agregar(ALquiler alquiler);

        bool Actualizar(ALquiler alquiler);

        bool Eliminar(int id);
    }
}
