using Asp.Versioning.ApiExplorer;
using Certificador.BLL.Api.Config;
using Certificador.BSV.Api.Config;
using Certificador.SVL.Api.Config;
using Certificador.DAL.Api;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Configuracion de CORS
const string CORS_POLICY = "CorsPolicy";
var corsValue = builder.Configuration.GetSection(CORS_POLICY).Value;

// Configuraciones de Capas
builder.Services.AddBLLConfig();
builder.Services.AddBSVConfig();
builder.Services.AddSVLConfig(corsValue);

var connectionString = builder.Configuration.GetConnectionString("CertificadorConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("La cadena de conexión 'CertificadorConnection' no se encontró o está vacía.");
}

builder.Services.AddDbContext<CERTIFICADORContext>(options =>
{
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    );
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// La configuracion detallada de Swagger se maneja en ConfigureSwaggerOptions
builder.Services.AddSwaggerGen();

// Obtiene el proveedor de versiones para configurar Swagger.
var app = builder.Build();
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    var route = "api-certificado";
    var documentName = "{documentName}";
    var serviceName = "CertificadorAPI";

    app.UseSwagger(options => { options.RouteTemplate = $"{route}/{documentName}/{serviceName}.json"; });
    app.UseSwaggerUI(options =>
    {
        options.RoutePrefix = route;
        // Itera sobre las versiones para crear un endpoint
        foreach (var descrption in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/{route}/{descrption.GroupName}/{serviceName}.json",
                             descrption.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();

app.ConfigureCustomEndpoints();

app.UseCors(corsValue);

app.UseAuthorization();

app.MapControllers();

app.Run();
