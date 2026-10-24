using Alquileres.Servidor.DTOs;
using Alquileres.Servidor.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Alquileres.Servidor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropiedadController : ControllerBase
    {
        private readonly IPropiedadService service;

        public PropiedadController(IPropiedadService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            return Ok(service.ObtenerTodos());
        }


        [HttpGet("{Id:int}")]
        public IActionResult ObtenerPorId([FromRoute(Name = "Id")] int id)
        {
            var propiedad = service.ObtenerPorId(id);

            if (propiedad == null)
                return NotFound("La propiedad no existe.");

            return Ok(propiedad);
        }

        [HttpPost]
        public IActionResult Crear(PropiedadCreateDto dto)
        {
            var propiedad = service.Crear(dto);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = propiedad.Id },
                propiedad);
        }

        [HttpPut("{id:int}")]
        public IActionResult Modificar(
            int id, PropiedadUpdateDto dto)
        {
            try
            {
                var propiedad = service.Modificar(id, dto);

                if (propiedad == null)
                    return NotFound("La propiedad no existe.");

                return Ok(propiedad);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Eliminar(int id)
        {
            bool eliminado = service.Eliminar(id);

            if (!eliminado)
                return NotFound("La propiedad no existe.");

            return NoContent();
        }
    }
}


