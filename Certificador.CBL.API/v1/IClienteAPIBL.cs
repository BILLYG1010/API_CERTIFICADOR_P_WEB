using Certificador.DTO.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificador.CBL.Api.v1
{
    public interface IClienteAPIBL
    {
        Task<List<ClienteAPIDTO>> ObtenerTodos();
        Task<ClienteAPIDTO> ObtenerPorId(int id);
        Task<ClienteAPIDTO> CrearCliente(ClienteAPIDTO cliente);
        Task<ClienteAPIDTO> EliminarCliente(int idCliente);
        Task<ClienteAPIDTO> ActualizarCliente(ClienteAPIDTO cliente);
    }
}
