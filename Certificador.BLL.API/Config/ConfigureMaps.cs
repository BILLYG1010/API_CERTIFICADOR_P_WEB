using AutoMapper;
using Certificador.DAL.Api.Entities;
using Certificador.DTO.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificador.BLL.Api.Config
{
    public class ConfigureMaps : Profile
    {
        public ConfigureMaps()
        {
            CreateMap<ClienteAPIDTO, ClienteAPI>().ReverseMap();
            CreateMap<FacturaDTO, Factura>().ReverseMap();
            CreateMap<FacturaCertificadaDTO, FacturaCertificada>().ReverseMap();
        }
    }
}
