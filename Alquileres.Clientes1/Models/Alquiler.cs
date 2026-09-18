using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquileres.Clientes1.Models
{
    public class Alquiler
    {
        //Atributos de los Alquiler
        public int Id { get; set; }

        public int PropiedadId { get; set; }

        public string Cliente { get; set; } = string.Empty;

        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }
    }
}
