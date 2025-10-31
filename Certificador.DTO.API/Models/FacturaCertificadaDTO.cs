using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificador.DTO.Api.Models
{
    public class FacturaCertificadaDTO
    {
        public int IdFacturaCertificada { get; set; }
        public int IdFactura { get; set; }
        public Guid NumeroAutorizacion { get; set; }
        public string Serie { get; set; }
        public int Correlativo { get; set; }
        public DateTime FechaCertificacion { get; set; }
        public bool? Estado { get; set; }
    }
}
