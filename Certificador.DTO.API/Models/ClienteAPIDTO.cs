using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificador.DTO.Api.Models
{
    public class ClienteAPIDTO
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string NIT { get; set; }
        public string ApiKeyHash { get; set; }
        public bool? EstadoCliente { get; set; }
        public bool EstadoPago { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime ActualizadoEn { get; set; }
    }
}
