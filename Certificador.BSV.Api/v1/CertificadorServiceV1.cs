using Certificador.CBL.Api.v1;
using Certificador.CSV.Api.v1;
using Certificador.DTO.Api;
using Certificador.DTO.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificador.BSV.Api.v1
{
    public class CertificadorServiceV1 : ICertificadorServiceV1, ICertificadorProxyServiceV1
    {
        private readonly IClienteAPIBL _clienteBL;
        private readonly IFacturaBL _facturaBL;
        private readonly IFacturaCertificadaBL _facturaCertificadaBL;

        public CertificadorServiceV1(IClienteAPIBL clienteBL, IFacturaBL facturaBL, IFacturaCertificadaBL facturaCertificadaBL)
        {
            _clienteBL = clienteBL;
            _facturaBL = facturaBL;
            _facturaCertificadaBL = facturaCertificadaBL;
        }

        //Crea un nuevo cliente
        public async Task<ResponseDTO<ClienteAPIDTO>> CrearCliente(ClienteAPIDTO cliente)
        {
            var response = new ResponseDTO<ClienteAPIDTO>();
            try
            {
                // Llama al metodo para crear el cliente.
                var result = await _clienteBL.CrearCliente(cliente);

                // Verifica si la creacion fue exitosa.
                if (result == null || result.IdCliente == 0)
                {
                    response.Success = false;
                    response.ErrorMessage = "Ocurrio un error inesperado al crear el cliente.";
                    response.DisplayMessage = "El cliente no pudo ser creado correctamente.";
                }
                else
                {
                    response.Success = true;
                    response.SingleResult = result;
                    response.DisplayMessage = "El cliente se creo correctamente.";
                }
            }
            catch (Exception ex)
            {
                // Manejo de cualquier excepcion.
                response.Success = false;
                response.ErrorMessage = ex.Message;
                response.DisplayMessage = "Ocurrio un error inesperado al intentar crear el cliente.";
            }
            return response;
        }

        // Crea una nueva factura
        public async Task<ResponseDTO<FacturaDTO>> CrearFactura(FacturaDTO factura)
        {
            var response = new ResponseDTO<FacturaDTO>();
            try
            {
                // Llama al metodo para crear la factura
                var result = await _facturaBL.CrearFactura(factura);

                // Verifica creacion
                if (result == null || result.IdFactura == 0)
                {
                    response.Success = false;
                    response.ErrorMessage = "Error al crear factura.";
                    response.DisplayMessage = "La factura no pudo ser creada.";
                }
                else
                {
                    response.Success = true;
                    response.SingleResult = result;
                    response.DisplayMessage = "La factura se creo correctamente.";
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepcion
                response.Success = false;
                response.ErrorMessage = "Error inesperado.";
                response.DisplayMessage = ex.Message;
            }
            return response;
        }

        // Crea una nueva factura certificada
        public async Task<ResponseDTO<FacturaCertificadaDTO>> CrearFacturaCertificada(FacturaCertificadaDTO facturaCertificada)
        {
            var response = new ResponseDTO<FacturaCertificadaDTO>();
            try
            {
                // Llama al metodo para crear factura certificada
                var result = await _facturaCertificadaBL.CrearFacturaCertificada(facturaCertificada);

                // Verifica si la creacion fue exitosa.
                if (result == null || result.IdFacturaCertificada == 0)
                {
                    response.Success = false;
                    response.ErrorMessage = "Error al crear factura certificada.";
                    response.DisplayMessage = "La factura certificada no pudo ser creada.";
                }
                else
                {
                    response.Success = true;
                    response.SingleResult = result;
                    response.DisplayMessage = "La factura certificada se creo correctamente.";
                }
            }
            catch (Exception ex)
            {
                // Manejo de cualquier excepcion.
                response.Success = false;
                response.ErrorMessage = "Error inesperado.";
                response.DisplayMessage = ex.Message;
            }
            return response;
        }

        // Edita un cliente
        public async Task<ResponseDTO<ClienteAPIDTO>> EditarCliente(ClienteAPIDTO cliente)
        {
            var response = new ResponseDTO<ClienteAPIDTO>();
            try
            {
                // Llama al metodo para actualizar cliente
                var result = await _clienteBL.ActualizarCliente(cliente);

                // Verifica si la actualizacion fue exitosa.
                if (result == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Error al editar cliente.";
                    response.DisplayMessage = "No se pudo editar el cliente.";
                }
                else
                {
                    response.Success = true;
                    response.SingleResult = result;
                    response.DisplayMessage = "El cliente se edito correctamente.";
                }
            }
            catch (Exception ex)
            {
                // Manejo de cualquier excepcion.
                response.Success = false;
                response.ErrorMessage = "Error inesperado.";
                response.DisplayMessage = ex.Message;
            }
            return response;
        }

        // Edita una factura
        public async Task<ResponseDTO<FacturaDTO>> EditarFactura(FacturaDTO factura)
        {
            var response = new ResponseDTO<FacturaDTO>();
            try
            {
                // Llama al metodo para actualizar factura
                var result = await _facturaBL.ActualizarFactura(factura);

                // Verifica si la actualizacion fue exitosa.
                if (result == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Error al editar factura.";
                    response.DisplayMessage = "No se pudo editar la factura.";
                }
                else
                {
                    response.Success = true;
                    response.SingleResult = result;
                    response.DisplayMessage = "La factura se edito correctamente.";
                }
            }
            catch (Exception ex)
            {
                // Manejo de cualquier excepcion.
                response.Success = false;
                response.ErrorMessage = "Error inesperado.";
                response.DisplayMessage = ex.Message;
            }
            return response;
        }

        // Edita una factura certificada
        public async Task<ResponseDTO<FacturaCertificadaDTO>> EditarFacturaCertificada(FacturaCertificadaDTO facturaCertificada)
        {
            var response = new ResponseDTO<FacturaCertificadaDTO>();
            try
            {
                // Llama al metodo para actualizar factura certificada
                var result = await _facturaCertificadaBL.ActualizarFacturaCertificada(facturaCertificada);

                // Verifica si la actualizacion fue exitosa.
                if (result == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Error al editar factura certificada.";
                    response.DisplayMessage = "No se pudo editar la factura certificada.";
                }
                else
                {
                    response.Success = true;
                    response.SingleResult = result;
                    response.DisplayMessage = "La factura certificada se edito correctamente.";
                }
            }
            catch (Exception ex)
            {
                // Manejo de cualquier excepcion.
                response.Success = false;
                response.ErrorMessage = "Error inesperado.";
                response.DisplayMessage = ex.Message;
            }
            return response;
        }

        // Elimina un cliente
        public async Task<ResponseDTO<ClienteAPIDTO>> EliminarCliente(int id)
        {
            // Validacion de ID
            if (id <= 0)
            {
                return new ResponseDTO<ClienteAPIDTO>()
                {
                    Success = false,
                    ErrorMessage = "ID incorrecto.",
                    DisplayMessage = "El ID debe ser mayor a 0."
                };
            }

            var response = new ResponseDTO<ClienteAPIDTO>();
            try
            {
                // Llama al metodo para eliminar cliente
                var result = await _clienteBL.EliminarCliente(id);

                // Verifica si la eliminacion fue exitosa.
                if (result == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Error al eliminar cliente.";
                    response.DisplayMessage = "No se pudo eliminar cliente con el ID: {id}.";
                }
                else
                {
                    response.Success = true;
                    response.SingleResult = result;
                    response.DisplayMessage = "El cliente se elimino correctamente.";
                }
            }
            catch (Exception ex)
            {
                // Manejo de cualquier excepcion.
                response.Success = false;
                response.ErrorMessage = "Error inesperado.";
                response.DisplayMessage = ex.Message;
            }
            return response;
        }

        // Elimina una factura
        public async Task<ResponseDTO<FacturaDTO>> EliminarFactura(int id)
        {
            // Validacion de ID
            if (id <= 0)
            {
                return new ResponseDTO<FacturaDTO>()
                {
                    Success = false,
                    ErrorMessage = "ID incorrecto.",
                    DisplayMessage = "El ID debe ser mayor a 0."
                };
            }

            var response = new ResponseDTO<FacturaDTO>();
            try
            {
                // Llama al metodo para eliminar factura
                var result = await _facturaBL.EliminarFactura(id);

                // Verifica si la eliminacion fue exitosa.
                if (result == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Error al eliminar factura.";
                    response.DisplayMessage = "No se pudo eliminar factura con el ID: {id}.";
                }
                else
                {
                    response.Success = true;
                    response.SingleResult = result;
                    response.DisplayMessage = "La factura se elimino correctamente.";
                }
            }
            catch (Exception ex)
            {
                // Manejo de cualquier excepcion.
                response.Success = false;
                response.ErrorMessage = "Error inesperado.";
                response.DisplayMessage = ex.Message;
            }
            return response;
        }

        // Elimina una factura certificada
        public async Task<ResponseDTO<FacturaCertificadaDTO>> EliminarFacturaCertificada(int id)
        {
            // Validacion de ID
            if (id <= 0)
            {
                return new ResponseDTO<FacturaCertificadaDTO>()
                {
                    Success = false,
                    ErrorMessage = "ID incorrecto.",
                    DisplayMessage = "El ID debe ser mayor a 0."
                };
            }

            var response = new ResponseDTO<FacturaCertificadaDTO>();
            try
            {
                // Llama al metodo para eliminar factura certificada
                var result = await _facturaCertificadaBL.EliminarFacturaCertificada(id);

                // Verifica si la eliminacion fue exitosa.
                if (result == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Error al eliminar factura certificada.";
                    response.DisplayMessage = "No se pudo eliminar factura certificada con el ID: {id}.";
                }
                else
                {
                    response.Success = true;
                    response.SingleResult = result;
                    response.DisplayMessage = "La factura certificada se elimino correctamente.";
                }
            }
            catch (Exception ex)
            {
                // Manejo de cualquier excepcion.
                response.Success = false;
                response.ErrorMessage = "Error inesperado.";
                response.DisplayMessage = ex.Message;
            }
            return response;
        }

        // Obtiene cliente por ID
        public async Task<ResponseDTO<ClienteAPIDTO>> ObtenerClientePorId(int id)
        {
            var response = new ResponseDTO<ClienteAPIDTO>();

            try
            {
                if (id == 0)
                {
                    response.SingleResult = new ClienteAPIDTO();
                    response.Success = false;
                    response.ErrorMessage = "Ocurrio un error inesperado.";
                    response.DisplayMessage = "El Id del cliente es requerido.";
                }
                else
                {
                    // Llama al metodo para obtener por ID
                    var result = await _clienteBL.ObtenerPorId(id);

                    // Verifica si la operacion fue exitosa.
                    if (result == null)
                    {
                        response.Success = false;
                        response.ErrorMessage = "Ocurrio un error inesperado.";
                        response.DisplayMessage = "No se encontro ningun cliente con el Id especificado.";
                    }
                    else
                    {
                        response.Success = true;
                        response.SingleResult = result;
                        response.DisplayMessage = "El cliente se obtuvo correctamente.";
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de cualquier excepcion.
                response.Success = false;
                response.ErrorMessage = "Ocurrio un error inesperado.";
                response.DisplayMessage = ex.Message;
            }
            return response;
        }

        // Obtiene todos los clientes
        public async Task<ResponseDTO<List<ClienteAPIDTO>>> ObtenerClientes()
        {
            var response = new ResponseDTO<List<ClienteAPIDTO>>();
            try
            {
                // Llama al metodo para obtener todos
                var result = await _clienteBL.ObtenerTodos();

                // Verifica si la operacion fue exitosa.
                if (result == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Ocurrio un error inesperado.";
                    response.DisplayMessage = "No se pudo obtener el listado de clientes.";
                }
                else
                {
                    response.Success = true;
                    response.SingleResult = result;
                    response.DisplayMessage = "El listado de clientes se obtuvo correctamente.";
                }
            }
            catch (Exception ex)
            {
                // Manejo de cualquier excepcion.
                response.Success = false;
                response.ErrorMessage = "Ocurrio un error inesperado.";
                response.DisplayMessage = ex.Message;
            }
            return response;
        }

        // Obtiene factura certificada por ID
        public async Task<ResponseDTO<FacturaCertificadaDTO>> ObtenerFacturaCertificadaPorId(int id)
        {
            var response = new ResponseDTO<FacturaCertificadaDTO>();

            try
            {
                if (id == 0)
                {
                    response.SingleResult = new FacturaCertificadaDTO();
                    response.Success = false;
                    response.ErrorMessage = "Ocurrio un error inesperado.";
                    response.DisplayMessage = "El Id de la factura certificada es requerido.";
                }
                else
                {
                    // Llama al metodo para obtener por ID
                    var result = await _facturaCertificadaBL.ObtenerPorId(id);

                    // Verifica si la operacion fue exitosa.
                    if (result == null)
                    {
                        response.Success = false;
                        response.ErrorMessage = "Ocurrio un error inesperado.";
                        response.DisplayMessage = "No se encontro ninguna factura certificada con el Id especificado.";
                    }
                    else
                    {
                        response.Success = true;
                        response.SingleResult = result;
                        response.DisplayMessage = "La factura certificada se obtuvo correctamente.";
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de cualquier excepcion.
                response.Success = false;
                response.ErrorMessage = "Ocurrio un error inesperado.";
                response.DisplayMessage = ex.Message;
            }
            return response;
        }

        // Obtiene factura por ID
        public async Task<ResponseDTO<FacturaDTO>> ObtenerFacturaPorId(int id)
        {
            var response = new ResponseDTO<FacturaDTO>();

            try
            {
                if (id == 0)
                {
                    response.SingleResult = new FacturaDTO();
                    response.Success = false;
                    response.ErrorMessage = "Ocurrio un error inesperado.";
                    response.DisplayMessage = "El Id de la factura es requerido.";
                }
                else
                {
                    // Llama al metodo para obtener por ID
                    var result = await _facturaBL.ObtenerPorId(id);

                    // Verifica si la operacion fue exitosa.
                    if (result == null)
                    {
                        response.Success = false;
                        response.ErrorMessage = "Ocurrio un error inesperado.";
                        response.DisplayMessage = "No se encontro ninguna factura con el Id especificado.";
                    }
                    else
                    {
                        response.Success = true;
                        response.SingleResult = result;
                        response.DisplayMessage = "La factura se obtuvo correctamente.";
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de cualquier excepcion.
                response.Success = false;
                response.ErrorMessage = "Ocurrio un error inesperado.";
                response.DisplayMessage = ex.Message;
            }
            return response;
        }

        // Obtiene todas las facturas
        public async Task<ResponseDTO<List<FacturaDTO>>> ObtenerFacturas()
        {
            var response = new ResponseDTO<List<FacturaDTO>>();
            try
            {
                // Llama al metodo para obtener todas
                var result = await _facturaBL.ObtenerTodos();

                // Verifica si la operacion fue exitosa.
                if (result == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Ocurrio un error inesperado.";
                    response.DisplayMessage = "No se pudo obtener el listado de facturas.";
                }
                else
                {
                    response.Success = true;
                    response.SingleResult = result;
                    response.DisplayMessage = "El listado de facturas se obtuvo correctamente.";
                }
            }
            catch (Exception ex)
            {
                // Manejo de cualquier excepcion.
                response.Success = false;
                response.ErrorMessage = "Ocurrio un error inesperado.";
                response.DisplayMessage = ex.Message;
            }
            return response;
        }

        // Obtiene todas las facturas certificadas
        public async Task<ResponseDTO<List<FacturaCertificadaDTO>>> ObtenerFacturasCertificadas()
        {
            var response = new ResponseDTO<List<FacturaCertificadaDTO>>();
            try
            {
                // Llama al metodo para obtener todas
                var result = await _facturaCertificadaBL.ObtenerTodos();

                // Verifica si la operacion fue exitosa.
                if (result == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Ocurrio un error inesperado.";
                    response.DisplayMessage = "No se pudo obtener el listado de facturas certificadas.";
                }
                else
                {
                    response.Success = true;
                    response.SingleResult = result;
                    response.DisplayMessage = "El listado de facturas certificadas se obtuvo correctamente.";
                }
            }
            catch (Exception ex)
            {
                // Manejo de cualquier excepcion.
                response.Success = false;
                response.ErrorMessage = "Ocurrio un error inesperado.";
                response.DisplayMessage = ex.Message;
            }
            return response;
        }
    }
}
