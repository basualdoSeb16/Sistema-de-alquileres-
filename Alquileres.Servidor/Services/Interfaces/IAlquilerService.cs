using Alquileres.Servidor.DTOs;
using Alquileres.Servidor.Models;
using System.Collections.Generic;
namespace Alquileres.Servidor.Services.Interfaces
{
    public interface IAlquilerService
    {
        List<ALquiler> ObtenerTodos();

        ALquiler? ObtenerPorId(int id);

        ALquiler Crear(AlquilerCreateDto dto);

        ALquiler? Modificar(int id, AlquilerUpdateDto dto);

        bool Eliminar(int id);
    }
}
