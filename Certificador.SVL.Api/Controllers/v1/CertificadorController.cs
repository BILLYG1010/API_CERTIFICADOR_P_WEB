using Asp.Versioning;
using Certificador.CSV.Api.v1;
using Certificador.DTO.Api;
using Certificador.DTO.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Certificador.SVL.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/certificador")]
    public class CertificadorController : Controller
    {
        private readonly ICertificadorServiceV1 _certificadorServiceV1;

        // Constructor con inyeccion de dependencia
        public CertificadorController(ICertificadorServiceV1 certificadorServiceV1)

        {
            _certificadorServiceV1 = certificadorServiceV1;
        }

        //Metodos para Cliente

        /// <summary>
        /// Obtener Clientes
        /// </summary>
        /// <returns>Listado de DTOs de clientes.</returns>
        [HttpGet("clientes", Name = "ObtenerClientesAsync")]
        public async Task<ResponseDTO<List<ClienteAPIDTO>>> ObtenerClientes()
        {
            return await _certificadorServiceV1.ObtenerClientes();
        }

        /// <summary>
        /// Obtener Cliente por Id
        /// </summary>
        /// <param name="id">ID del cliente a obtener.</param>
        /// <returns>DTO del cliente obtenido por el ID.</returns>
        [HttpGet("clientes/detalle/{id:int}", Name = "ObtenerClientePorIdAsync")]
        public async Task<ResponseDTO<ClienteAPIDTO>> ObtenerClientePorId(int id)
        {
            return await _certificadorServiceV1.ObtenerClientePorId(id);
        }

        /// <summary>
        /// Crear Cliente
        /// </summary>
        /// <param name="model">DTO del cliente a crear.</param>
        /// <returns>DTO del cliente creado.</returns>
        [HttpPost("clientes", Name = "CrearClienteAsync")]
        public async Task<ResponseDTO<ClienteAPIDTO>> CrearCliente(ClienteAPIDTO model)
        {
            return await _certificadorServiceV1.CrearCliente(model);
        }

        /// <summary>
        /// Editar Cliente
        /// </summary>
        /// <param name="model">DTO del cliente a editar.</param>
        /// <returns>DTO del cliente editado.</returns>
        [HttpPut("clientes", Name = "ActualizarClienteAsync")]
        public async Task<ResponseDTO<ClienteAPIDTO>> ActualizarCliente(ClienteAPIDTO model)
        {
            return await _certificadorServiceV1.EditarCliente(model);
        }

        /// <summary>
        /// Eliminar Cliente
        /// </summary>
        /// <param name="id">ID del cliente a eliminar (borrado logico).</param>
        /// <returns>DTO del cliente eliminado.</returns>
        [HttpPut("clientes/eliminar/{id:int}", Name = "EliminarClienteAsync")]
        public async Task<ResponseDTO<ClienteAPIDTO>> EliminarCliente(int id)
        {
            return await _certificadorServiceV1.EliminarCliente(id);
        }

        //Metodos para Factura
        /// <summary>
        /// Obtener Facturas
        /// </summary>
        /// <returns>Listado de DTOs de facturas.</returns>
        [HttpGet("facturas", Name = "ObtenerFacturasAsync")]
        public async Task<ResponseDTO<List<FacturaDTO>>> ObtenerFacturas()
        {
            return await _certificadorServiceV1.ObtenerFacturas();
        }

        /// <summary>
        /// Obtener Factura por Id
        /// </summary>
        /// <param name="id">ID de la factura a obtener.</param>
        /// <returns>DTO de la factura obtenida por el ID.</returns>
        [HttpGet("facturas/detalle/{id:int}", Name = "ObtenerFacturaPorIdAsync")]
        public async Task<ResponseDTO<FacturaDTO>> ObtenerFacturaPorId(int id)
        {
            return await _certificadorServiceV1.ObtenerFacturaPorId(id);
        }

        /// <summary>
        /// Crear Factura
        /// </summary>
        /// <param name="model">DTO de la factura a crear.</param>
        /// <returns>DTO de la factura creada.</returns>
        [HttpPost("facturas", Name = "CrearFacturaAsync")]
        public async Task<ResponseDTO<FacturaDTO>> CrearFactura(FacturaDTO model)
        {
            return await _certificadorServiceV1.CrearFactura(model);
        }

        /// <summary>
        /// Editar Factura
        /// </summary>
        /// <param name="model">DTO de la factura a editar.</param>
        /// <returns>DTO de la factura editada.</returns>
        [HttpPut("facturas", Name = "ActualizarFacturaAsync")]
        public async Task<ResponseDTO<FacturaDTO>> ActualizarFactura(FacturaDTO model)
        {
            return await _certificadorServiceV1.EditarFactura(model);
        }

        /// <summary>
        /// Eliminar Factura
        /// </summary>
        /// <param name="id">ID de la factura a eliminar (borrado logico).</param>
        /// <returns>DTO de la factura eliminada.</returns>
        [HttpPut("facturas/eliminar/{id:int}", Name = "EliminarFacturaAsync")]
        public async Task<ResponseDTO<FacturaDTO>> EliminarFactura(int id)
        {
            return await _certificadorServiceV1.EliminarFactura(id);
        }

        //Metodos para FacturaCertificada
        //Las Facturas Certificadas seran lecturas, y no suelen tener metodos ya que solo es un proceso que se realiza.

        /// <summary>
        /// Obtener Facturas Certificadas
        /// </summary>
        /// <returns>Listado de DTOs de facturas certificadas.</returns>
        [HttpGet("facturas/certificadas", Name = "ObtenerFacturasCertificadasAsync")]
        public async Task<ResponseDTO<List<FacturaCertificadaDTO>>> ObtenerFacturasCertificadas()
        {
            return await _certificadorServiceV1.ObtenerFacturasCertificadas();
        }

        /// <summary>
        /// Obtener Factura Certificada por Id
        /// </summary>
        /// <param name="id">ID de la factura certificada a obtener.</param>
        /// <returns>DTO de la factura certificada obtenida por el ID.</returns>
        [HttpGet("facturas/certificadas/detalle/{id:int}", Name = "ObtenerFacturaCertificadaPorIdAsync")]
        public async Task<ResponseDTO<FacturaCertificadaDTO>> ObtenerFacturaCertificadaPorId(int id)
        {
            return await _certificadorServiceV1.ObtenerFacturaCertificadaPorId(id);
        }
    }
}