using Certificador.DTO.Api;
using Certificador.DTO.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Certificador.CSV.Api.v1
{
    // Define el nombre del contrato de servicio SOAP.
    [ServiceContract(Name = "CertificadorService")]
    public interface ICertificadorProxyServiceV1
    {
        //Metodos para Cliente

        [OperationContract(Name = "ObtenerClientes")]
        Task<ResponseDTO<List<ClienteAPIDTO>>> ObtenerClientes();

        [OperationContract(Name = "ObtenerClientePorId")]
        Task<ResponseDTO<ClienteAPIDTO>> ObtenerClientePorId(int id);

        [OperationContract(Name = "CrearCliente")]
        Task<ResponseDTO<ClienteAPIDTO>> CrearCliente(ClienteAPIDTO cliente);

        [OperationContract(Name = "EditarCliente")]
        Task<ResponseDTO<ClienteAPIDTO>> EditarCliente(ClienteAPIDTO cliente);

        [OperationContract(Name = "EliminarCliente")]
        Task<ResponseDTO<ClienteAPIDTO>> EliminarCliente(int id);

        //Metodos para Factura

        [OperationContract(Name = "ObtenerFacturas")]
        Task<ResponseDTO<List<FacturaDTO>>> ObtenerFacturas();

        [OperationContract(Name = "ObtenerFacturaPorId")]
        Task<ResponseDTO<FacturaDTO>> ObtenerFacturaPorId(int id);

        [OperationContract(Name = "CrearFactura")]
        Task<ResponseDTO<FacturaDTO>> CrearFactura(FacturaDTO factura);

        [OperationContract(Name = "EditarFactura")]
        Task<ResponseDTO<FacturaDTO>> EditarFactura(FacturaDTO factura);

        [OperationContract(Name = "EliminarFactura")]
        Task<ResponseDTO<FacturaDTO>> EliminarFactura(int id);

        //Metodos para Factura Caertificada

        [OperationContract(Name = "ObtenerFacturasCertificadas")]
        Task<ResponseDTO<List<FacturaCertificadaDTO>>> ObtenerFacturasCertificadas();

        [OperationContract(Name = "ObtenerFacturaCertificadaPorId")]
        Task<ResponseDTO<FacturaCertificadaDTO>> ObtenerFacturaCertificadaPorId(int id);
    }
}
