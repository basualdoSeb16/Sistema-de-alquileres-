using Alquileres.Servidor.Models;
using Alquileres.Servidor.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
namespace Alquileres.Servidor.Repositories.Implementations
{
    public class AlquilerRepository : IAlquilerRepository
    {
        // Lista temporal donde se guardan los alquileres.
        private static readonly List<ALquiler> alquileres = new();

        // Obtener todos los alquileres.
        public List<ALquiler> ObtenerTodos()
        {
            return alquileres.ToList();
        }

        // Buscar un alquiler por su ID.
        public ALquiler? ObtenerPorId(int id)
        {
            return alquileres.FirstOrDefault(a => a.Id == id);
        }

        // Agregar un alquiler y generar su ID.
        public ALquiler Agregar(ALquiler alquiler)
        {
            alquiler.Id = alquileres.Count == 0
                ? 1
                : alquileres.Max(a => a.Id) + 1;

            alquileres.Add(alquiler);

            return alquiler;
        }

        // Modificar un alquiler existente.
        public bool Actualizar(ALquiler alquiler)
        {
            int indice = alquileres.FindIndex(
                a => a.Id == alquiler.Id
            );

            if (indice == -1)
                return false;

            alquileres[indice] = alquiler;

            return true;
        }

        // Eliminar un alquiler por su ID.
        public bool Eliminar(int id)
        {
            var alquiler = ObtenerPorId(id);

            if (alquiler == null)
                return false;

            alquileres.Remove(alquiler);

            return true;
        }
    }
}
