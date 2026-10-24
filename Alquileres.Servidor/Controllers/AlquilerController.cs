
using Alquileres.Servidor.DTOs;
using Alquileres.Servidor.Models;
using Alquileres.Servidor.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Alquileres.Servidor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlquilerController : ControllerBase
    {
        private readonly IAlquilerService alquilerService;

        public AlquilerController(IAlquilerService alquilerService)
        {
            this.alquilerService = alquilerService;
        }

        // GET: api/Alquiler
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            return Ok(alquilerService.ObtenerTodos());
        }

        // GET: api/Alquiler/1
        [HttpGet("{id:int}")]
        public IActionResult ObtenerPorId(int id)
        {
            var alquiler = alquilerService.ObtenerPorId(id);

            if (alquiler == null)
            {
                return NotFound("El alquiler no existe.");
            }

            return Ok(alquiler);
        }

        // POST: api/Alquiler
        [HttpPost]
        public IActionResult Crear([FromBody] AlquilerCreateDto dto)
        {
            try
            {
                var alquiler = alquilerService.Crear(dto);

                return CreatedAtAction(
                    nameof(ObtenerPorId),
                    new { id = alquiler.Id },
                    alquiler);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Alquiler/1
        [HttpPut("{id:int}")]
        public IActionResult Modificar(
            int id,
            [FromBody] AlquilerUpdateDto dto)
        {
            try
            {
                var alquiler = alquilerService.Modificar(id, dto);

                if (alquiler == null)
                {
                    return NotFound("El alquiler no existe.");
                }

                return Ok(alquiler);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Alquiler/1
        [HttpDelete("{id:int}")]
        public IActionResult Eliminar(int id)
        {
            bool eliminado = alquilerService.Eliminar(id);

            if (!eliminado)
            {
                return NotFound("El alquiler no existe.");
            }

            return Ok("Alquiler eliminado correctamente.");
        }
    }
}
