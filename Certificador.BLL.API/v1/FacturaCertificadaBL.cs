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
    public class FacturaCertificadaBL : IFacturaCertificadaBL
    {
        private readonly CERTIFICADORContext _certificadoContext;
        private readonly IMapper _mapper;

        public FacturaCertificadaBL(CERTIFICADORContext certificadoContext, IMapper mapper)
        {
            _certificadoContext = certificadoContext;
            _mapper = mapper;
        }

        public async Task<FacturaCertificadaDTO> ActualizarFacturaCertificada(FacturaCertificadaDTO facturaCertificada)
        {
            var facturaCertificada1 = _mapper.Map<FacturaCertificada>(facturaCertificada);
            facturaCertificada.Estado = true;
            _certificadoContext.FacturaCertificada.Update(facturaCertificada1);
            await _certificadoContext.SaveChangesAsync();
            return _mapper.Map<FacturaCertificadaDTO>(facturaCertificada1);
        }

        public async Task<FacturaCertificadaDTO> CrearFacturaCertificada(FacturaCertificadaDTO facturaCertificada)
        {
            var facturaCertificada1 = _mapper.Map<FacturaCertificada>(facturaCertificada);
            facturaCertificada.Estado = true;
            _certificadoContext.FacturaCertificada.Add(facturaCertificada1);
            await _certificadoContext.SaveChangesAsync();
            return _mapper.Map<FacturaCertificadaDTO>(facturaCertificada1);
        }

        public async Task<FacturaCertificadaDTO> EliminarFacturaCertificada(int idFacturaCertificada)
        {
            var facturaCertificada = await _certificadoContext.FacturaCertificada
                   .FirstOrDefaultAsync(x => x.IdFacturaCertificada == idFacturaCertificada && x.Estado == true);
            if (facturaCertificada == null)
                return new FacturaCertificadaDTO();

            facturaCertificada.Estado = false;
            _certificadoContext.FacturaCertificada.Update(facturaCertificada);
            await _certificadoContext.SaveChangesAsync();
            return _mapper.Map<FacturaCertificadaDTO>(facturaCertificada);
        }

        public async Task<FacturaCertificadaDTO> ObtenerPorId(int id)
        {
            var facturaCertificada = await _certificadoContext.FacturaCertificada
        .Where(x => x.IdFacturaCertificada == id).FirstOrDefaultAsync();

            return _mapper.Map<FacturaCertificadaDTO>(facturaCertificada);
        }

        public async Task<List<FacturaCertificadaDTO>> ObtenerTodos()
        {
            var listadoFacturaCertificada = await _certificadoContext.FacturaCertificada
        .Where(x => x.Estado == true).ToListAsync();

            return _mapper.Map<List<FacturaCertificadaDTO>>(listadoFacturaCertificada);
        }
    }
}
