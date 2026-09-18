using Alquileres.Servidor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alquileres.Servidor.Controllers
{
    // Indica que esta clase es un controlador de una API y define la ruta.
    [ApiController]
    [Route("api/[controller]")]
    public class AlquilerController : ControllerBase
    {
        // Lista donde se almacenan los alquileres.
        private static List<ALquiler> alquileres = new()
        {

        };

        // Permite obtener todos los alquileres.
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(alquileres);
        }

        // Permite obtener un alquiler por su Id.
        [HttpGet("{Id}")]
        public IActionResult GetById(int id)
        {
            var alquiler = alquileres.FirstOrDefault(a => a.Id == id);

            if (alquiler == null)
            {
                return NotFound();
            }

            return Ok(alquiler);

        }

        // Permite crear un nuevo alquiler.
        [HttpPost] 
        public ActionResult<ALquiler> CrearAlquiler(ALquiler alquiler)
        {
            var propiedad = PropiedadController.ObtenerPropiedadPorId(alquiler.PropiedadId);
            if (propiedad == null)
            { 
                return NotFound("La propiedad no existe."); 
            } 
            
            if (propiedad.Estado != "Disponible")
            {
                return BadRequest("La propiedad no está disponible.");
            }

            alquileres.Add(alquiler);

            propiedad.Estado = "Alquilada";

            return CreatedAtAction(
                nameof(GetById),
                new { id = alquiler.Id },
                alquiler
            );
           
        }

    }
}
