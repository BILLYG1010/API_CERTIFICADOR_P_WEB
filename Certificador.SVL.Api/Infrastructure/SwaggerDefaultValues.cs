using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json;

namespace Certificador.SVL.Api.Infrastructure
{
    public class SwaggerDefaultValues : IOperationFilter
        {
        // Define el filtro de operacion para ajustar Swagger.
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var apiDescription = context.ApiDescription;
            operation.Deprecated |= apiDescription.IsDeprecated();

            // Itera sobre los tipos de respuesta soportados.
            foreach (var responseType in context.ApiDescription.SupportedResponseTypes)
            {
                var responseKey = responseType.IsDefaultResponse ? "default" : responseType.StatusCode.ToString();

                if (!operation.Responses.TryGetValue(responseKey, out var response))
                {
                    continue;
                }

                // Elimina Content-Types que no son soportados por el endpoint.
                foreach (var contentType in response.Content.Keys.ToList())
                {
                    if (responseType.ApiResponseFormats.All(x => x.MediaType != contentType))
                    {
                        response.Content.Remove(contentType);
                    }
                }

                // Verifica si hay parametros que procesar.
                if (operation.Parameters == null)
                {
                    return;
                }

                // Itera y aplica valores por defecto y descripciones a los parametros.
                foreach (var parameter in operation.Parameters)
                {
                    var descripcion = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);

                    // Asigna la descripcion del parametro.
                    parameter.Description ??= descripcion.ModelMetadata?.Description;

                    // Transfiere el valor por defecto al esquema de Swagger.
                    if (parameter.Schema.Default == null && descripcion.DefaultValue != null)
                    {
                        var json = JsonSerializer.Serialize(descripcion.DefaultValue, descripcion.ModelMetadata.ModelType);
                        parameter.Schema.Default = OpenApiAnyFactory.CreateFromJson(json);
                    }

                    // Marca el parametro como requerido.
                    parameter.Required |= descripcion.IsRequired;
                }
            }
        }
    }
}