using Certificador.DTO.Api;
using Certificador.DTO.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificador.CSV.Api.v1
{
    public interface ICertificadorServiceV1
    {
        //Cliente
        Task<ResponseDTO<List<ClienteAPIDTO>>> ObtenerClientes();
        Task<ResponseDTO<ClienteAPIDTO>> ObtenerClientePorId(int id);
        Task<ResponseDTO<ClienteAPIDTO>> CrearCliente(ClienteAPIDTO cliente);
        Task<ResponseDTO<ClienteAPIDTO>> EditarCliente(ClienteAPIDTO cliente);
        Task<ResponseDTO<ClienteAPIDTO>> EliminarCliente(int id);

        //Factura
        Task<ResponseDTO<List<FacturaDTO>>> ObtenerFacturas();
        Task<ResponseDTO<FacturaDTO>> ObtenerFacturaPorId(int id);
        Task<ResponseDTO<FacturaDTO>> CrearFactura(FacturaDTO factura);
        Task<ResponseDTO<FacturaDTO>> EditarFactura(FacturaDTO factura);
        Task<ResponseDTO<FacturaDTO>> EliminarFactura(int id);
        //FacturaCertificada
        Task<ResponseDTO<List<FacturaCertificadaDTO>>> ObtenerFacturasCertificadas();
        Task<ResponseDTO<FacturaCertificadaDTO>> ObtenerFacturaCertificadaPorId(int id);
        Task<ResponseDTO<FacturaCertificadaDTO>> CrearFacturaCertificada(FacturaCertificadaDTO facturaCertificada);
        Task<ResponseDTO<FacturaCertificadaDTO>> EditarFacturaCertificada(FacturaCertificadaDTO facturaCertificada);
        Task<ResponseDTO<FacturaCertificadaDTO>> EliminarFacturaCertificada(int id);
    }
}
