using System;
using System.ComponentModel.DataAnnotations;
namespace Alquileres.Servidor.DTOs
{
    public class AlquilerUpdateDto
    {
        [Range(1, int.MaxValue,
           ErrorMessage = "Debe seleccionar una propiedad válida.")]
        public int PropiedadId { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        [StringLength(100)]
        public string Cliente { get; set; } = string.Empty;

        [Required]
        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }
    }
}
