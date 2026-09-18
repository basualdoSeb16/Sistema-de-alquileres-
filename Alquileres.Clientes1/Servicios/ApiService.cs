using Alquileres.Clientes1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Alquileres.Clientes1.Servicios
{
    // Servicio encargado de comunicarse con la API.
    public class ApiService
    {
            // Cliente HTTP utilizado para enviar peticiones al servidor.
            private readonly HttpClient httpClient;

            public object MessageBox { get; private set; }

        // Constructor del servicio.
        public ApiService()
        {
            // Crea un cliente HTTP.
            httpClient = new HttpClient();

            // Define la dirección base de la API.
            httpClient.BaseAddress =
                    new Uri("https://localhost:7122/");
        }

        // Obtiene todas las propiedades desde el servidor.
        public async Task<List<Propiedad>?> ObtenerPropiedades()
        {
                return await httpClient.GetFromJsonAsync<List<Propiedad>>(
                    "api/Propiedad");
        }

        // Envía una nueva propiedad al servidor.
        public async Task<Propiedad?> CrearPropiedad(Propiedad propiedad)
        {
                var respuesta = await httpClient.PostAsJsonAsync(
                    "api/Propiedad",
                    propiedad);

                respuesta.EnsureSuccessStatusCode();

                return await respuesta.Content
                    .ReadFromJsonAsync<Propiedad>();
        }

        // Obtiene todos los alquileres desde el servidor.
        public async Task<List<Alquiler>?> ObtenerAlquileres()
        {
                return await httpClient.GetFromJsonAsync<List<Alquiler>>(
                    "api/Alquiler");
        }

        // Envía un nuevo alquiler al servidor.
        public async Task<Alquiler?> CrearAlquiler(Alquiler alquiler)
        {
                 var respuesta = await httpClient.PostAsJsonAsync(
                    "api/Alquiler",
                 alquiler);

                if (!respuesta.IsSuccessStatusCode)
                {
                    string mensaje = await respuesta.Content.ReadAsStringAsync();

                    throw new Exception(
                    $"Error {((int)respuesta.StatusCode)}: {mensaje}");
                }

                     return await respuesta.Content
                     .ReadFromJsonAsync<Alquiler>();

        }

    }
   


    
        
        
}

