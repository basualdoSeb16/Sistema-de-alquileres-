namespace Alquileres.Servidor.Models
{
    public class ALquiler
    {
        //Atributos de los Alquiler
            public int Id { get; set; }

            public int PropiedadId { get; set; }

            public string Cliente { get; set; } = string.Empty;

            public DateTime FechaInicio { get; set; }

            public DateTime? FechaFin { get; set; }
        
    }


    
}
