using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificador.DTO.Api.Models
{
    public class FacturaDTO
    {
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public string FacturaExternaId { get; set; }
        public string IdempotenciaKey { get; set; }
        public string DataOriginal { get; set; }
        public bool Estado { get; set; }
        public string ErrorCodigo { get; set; }
        public string ErrorMensaje { get; set; }
        public Guid? NumeroAutorizacion { get; set; }
        public string Serie { get; set; }
        public int? Correlativo { get; set; }
        public DateTime? FechaCertificacion { get; set; }
        public decimal? MontoTotal { get; set; }
        public string AnulacionMotivo { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        public bool? Activo { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime ActualizadoEn { get; set; }
    }
}
