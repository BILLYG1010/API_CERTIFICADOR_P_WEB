using Certificador.DTO.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificador.CBL.Api.v1
{
    public interface IFacturaBL
    {
        Task<List<FacturaDTO>> ObtenerTodos();
        Task<FacturaDTO> ObtenerPorId(int id);
        Task<FacturaDTO> CrearFactura(FacturaDTO factura);
        Task<FacturaDTO> EliminarFactura(int idFactura);
        Task<FacturaDTO> ActualizarFactura(FacturaDTO factura);
    }
}