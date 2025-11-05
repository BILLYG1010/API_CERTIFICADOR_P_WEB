using Certificador.DTO.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificador.CBL.Api.v1
{
    public interface IFacturaCertificadaBL
    {
        Task<List<FacturaCertificadaDTO>> ObtenerTodos();
        Task<FacturaCertificadaDTO> ObtenerPorId(int id);
        Task<FacturaCertificadaDTO> CrearFacturaCertificada(FacturaCertificadaDTO facturaCertificada);
        Task<FacturaCertificadaDTO> ActualizarFacturaCertificada(FacturaCertificadaDTO facturaCertificada);
        Task<FacturaCertificadaDTO> EliminarFacturaCertificada(int idFacturaCertificada);
    }
}
