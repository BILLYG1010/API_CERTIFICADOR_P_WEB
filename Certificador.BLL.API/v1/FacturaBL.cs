using AutoMapper;
using Certificador.CBL.Api.v1;
using Certificador.DAL.Api;
using Certificador.DAL.Api.Entities;
using Certificador.DTO.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificador.BLL.Api.v1
{
    public class FacturaBL : IFacturaBL
    {
        private readonly CERTIFICADORContext _certificadoContext;
        private readonly IMapper _mapper;

        public FacturaBL(CERTIFICADORContext certificadoContext, IMapper mapper)
        {
            _certificadoContext = certificadoContext;
            _mapper = mapper;
        }

        public async Task<FacturaDTO> ActualizarFactura(FacturaDTO factura)
        {
            var factura1 = _mapper.Map<Factura>(factura);
            factura.ActualizadoEn = DateTime.Now;
            factura.Activo = true;
            _certificadoContext.Factura.Update(factura1);
            await _certificadoContext.SaveChangesAsync();
            return _mapper.Map<FacturaDTO>(factura1);
        }

        public async Task<FacturaDTO> CrearFactura(FacturaDTO factura)
        {
            var factura1 = _mapper.Map<Factura>(factura);
            factura.CreadoEn = DateTime.Now;
            factura.ActualizadoEn = DateTime.Now;
            factura.Activo = true;
            _certificadoContext.Factura.Add(factura1);
            await _certificadoContext.SaveChangesAsync();
            return _mapper.Map<FacturaDTO>(factura1);
        }

        public async Task<FacturaDTO> EliminarFactura(int idFactura)
        {
            var factura = await _certificadoContext.Factura
                   .FirstOrDefaultAsync(x => x.IdFactura == idFactura && x.Activo == true);
            if (factura == null)
                return new FacturaDTO();

            factura.Activo = false;
            factura.ActualizadoEn = DateTime.Now;
            _certificadoContext.Factura.Update(factura);
            await _certificadoContext.SaveChangesAsync();
            return _mapper.Map<FacturaDTO>(factura);
        }

        public async Task<FacturaDTO> ObtenerPorId(int id)
        {
            var factura = await _certificadoContext.Factura
         .Where(x => x.IdFactura == id).FirstOrDefaultAsync();

            return _mapper.Map<FacturaDTO>(factura);
        }

        public async Task<List<FacturaDTO>> ObtenerTodos()
        {
            var listadoFacturas = await _certificadoContext.Factura
       .Where(x => x.Activo == true).ToListAsync();

            return _mapper.Map<List<FacturaDTO>>(listadoFacturas);
        }
    }
}

        