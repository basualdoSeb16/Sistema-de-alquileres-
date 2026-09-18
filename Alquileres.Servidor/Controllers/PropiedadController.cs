using Alquileres.Servidor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alquileres.Servidor.Controllers
{
    // Indica que esta clase es un controlador de una API y define la ruta.
    [ApiController]
    [Route("api/[controller]")]
    public class PropiedadController : ControllerBase
    {
        // Lista que almacena las propiedades.
        private static List<Propiedad> propiedades = new()
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

        // Permite obtener todas las propiedades.
        [HttpGet]
        public ActionResult Get() 
        { 
            return Ok(propiedades);
        }

        // Permite obtener una propiedad por su Id.
        [HttpGet("{Id}")]
        public IActionResult GetById(int id)
        {
            var propiedad = propiedades.FirstOrDefault(a => a.Id == id);

            if (propiedad == null)
            {
                return NotFound();
            }

            return Ok(propiedad);
        }

        // Busca una propiedad por Id para ser utilizada por otros controladores.
        public static Propiedad? ObtenerPropiedadPorId(int id)
        {
            return propiedades.FirstOrDefault(p => p.Id == id);
        }

        // Permite agregar una nueva propiedad.
        [HttpPost]
        public ActionResult Create(Propiedad propiedad)
        {
            propiedad.Id = propiedades.Any()
                ? propiedades.Max(a => a.Id) + 1
                : 1;

            propiedades.Add(propiedad);

            return CreatedAtAction(
                nameof(GetById),
                new { id = propiedad.Id },
                propiedad
            );

        }
        
    }
}


