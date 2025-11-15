using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Certificador.SVL.Api.Infrastructure
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        // Inyeccion de dependencias.
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        // Metodo de configuracion.
        public void Configure(SwaggerGenOptions options)
        {
            // Se crea un documento Swagger por cada version de API detectada
            foreach (var descripcion in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(descripcion.GroupName, InformacionVersionApi(descripcion));
            }
        }

        // Metodo para crear la informacion del Swagger.
        public static OpenApiInfo InformacionVersionApi(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                // Titulo y descripcion del servicio Certificador
                Title = "API Certificador SVL.",
                Version = description.ApiVersion.ToString(),
                Description = "Documentacion API servicio Certificador.",
                Contact = new OpenApiContact() { Name = "Sharon Canellon" }
            };

            // Agrega una advertencia si la version esta marcada como obsoleta
            if (description.IsDeprecated)
            {
                info.Description += " Esta version de la API esta obsoleta";
            }

            return info;
        }
    }
}