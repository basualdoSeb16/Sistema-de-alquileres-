namespace Alquileres.Servidor.Models
{
    public class Propiedad
    {
        //Aributos de las propiedades
        public int Id { get; set; } 
        public string Direccion { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public int Habitaciones { get; set; }
        public int Banios { get; set; }
        public decimal Precio { get; set; }
        public string Estado { get; set; } = string.Empty;

    }
}
