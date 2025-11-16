using Certificador.BLL.Api.v1;
using Certificador.CBL.Api.v1;
using Certificador.DAL.Api;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificador.BLL.Api.Config
{
    public static class ConfigureServices
    {
        private const string DBCONNECTION = "CertificadorConnection";

        public static IServiceCollection AddBLLConfig(this IServiceCollection services)

        {
            
            services.AddAutoMapper(typeof(ConfigureMaps));

            services.AddScoped<IClienteAPIBL, ClienteAPIBL>();
            services.AddScoped<IFacturaBL, FacturaBL>();
            services.AddScoped<IFacturaCertificadaBL, FacturaCertificadaBL>();

            return services;
        }
    }
}