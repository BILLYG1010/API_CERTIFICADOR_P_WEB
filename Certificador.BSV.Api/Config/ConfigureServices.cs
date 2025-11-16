using Certificador.BSV.Api.v1;
using Certificador.CSV.Api.v1;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SoapCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Certificador.BSV.Api.Config
{
    public static class ConfigureServices
    {
        // Configuracion de dependencias
        public static IServiceCollection AddBSVConfig(this IServiceCollection services)
        {
            //Mapeo
            services.AddScoped<ICertificadorServiceV1, CertificadorServiceV1>();
            services.AddScoped<ICertificadorServiceV1, CertificadorServiceV1>();

            return services;
        }

        // Configura los endpoints de los servicios SOAP
        public static IApplicationBuilder ConfigureCustomEndpoints(this IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                // Configura el endpoint SOAP usando la interfaz de servicio
                endpoints.UseSoapEndpoint<ICertificadorProxyServiceV1>
                ("/CertificadorService.svc", new SoapEncoderOptions(),
                SoapSerializer.DataContractSerializer);
            });

            return app;
        }
    }
}
