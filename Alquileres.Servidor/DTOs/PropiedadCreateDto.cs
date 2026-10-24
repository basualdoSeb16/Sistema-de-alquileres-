using System.ComponentModel.DataAnnotations;
namespace Alquileres.Servidor.DTOs
{
    public class PropiedadCreateDto
    {
        [Required]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        public string Tipo { get; set; } = string.Empty;

        [Range(0, 100)]
        public int Habitaciones { get; set; }

        [Range(0, 100)]
        public int Banios { get; set; }

        [Range(0.01, 999999999,
        ErrorMessage = "El precio debe ser mayor que cero.")]
        public decimal Precio { get; set; }
    }
}
