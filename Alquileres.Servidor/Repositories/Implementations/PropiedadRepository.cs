using Alquileres.Servidor.Models;
using Alquileres.Servidor.Repositories.Interfaces;
namespace Alquileres.Servidor.Repositories.Implementations
{
    public class PropiedadRepository : IPropiedadRepository
    {
        private readonly List<Propiedad> propiedades = new()
        {
            new Propiedad
            {
                Id = 1,
                Direccion = "Av. Belgrano 123",
                Tipo = "Casa",
                Habitaciones = 3,
                Banios = 2,
                Precio = 350000,
                Estado = "Disponible"
            },
            new Propiedad
            {
                Id = 2,
                Direccion = "San Martín 456",
                Tipo = "Departamento",
                Habitaciones = 2,
                Banios = 1,
                Precio = 250000,
                Estado = "Disponible"
            }
        };

        public List<Propiedad> ObtenerTodos()
        {
            return propiedades.ToList();
        }

        public Propiedad? ObtenerPorId(int id)
        {
            return propiedades.FirstOrDefault(p => p.Id == id);
        }

        public Propiedad Agregar(Propiedad propiedad)
        {
            propiedad.Id = propiedades.Count == 0
                ? 1
                : propiedades.Max(p => p.Id) + 1;

            propiedades.Add(propiedad);

            return propiedad;
        }

        public bool Actualizar(Propiedad propiedad)
        {
            int indice = propiedades.FindIndex(
                p => p.Id == propiedad.Id);

            if (indice == -1)
                return false;

            propiedades[indice] = propiedad;
            return true;
        }

        public bool Eliminar(int id)
        {
            Propiedad? propiedad = ObtenerPorId(id);

            if (propiedad == null)
                return false;

            propiedades.Remove(propiedad);
            return true;
        }
    }
}
