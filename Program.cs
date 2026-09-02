using AutosSOAP.Data;
using AutosSOAP.Services;
using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ======================================================
// CONEXIÓN A SQL SERVER
// ======================================================

builder.Services.AddDbContext<AutosDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AutosConnection")
    )
);

// ======================================================
// REGISTRO DEL SERVICIO DE AUTOS
// ======================================================

builder.Services.AddScoped<AutoService>();

// ======================================================
// SERVICIOS COREWCF (SOAP)
// ======================================================

builder.Services
    .AddServiceModelServices()
    .AddServiceModelMetadata();

builder.Services.AddSingleton<IServiceBehavior,
    UseRequestHeadersForMetadataAddressBehavior>();

// ======================================================
// CONFIGURACIÓN DE KESTREL
// ======================================================

builder.WebHost.ConfigureKestrel(options =>
{
    options.AllowSynchronousIO = true;
});

var app = builder.Build();

// ======================================================
// ENDPOINT DEL SERVICIO SOAP
// ======================================================

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder
        .AddService<AutoService>()
        .AddServiceEndpoint<AutoService, IAutoService>(
            new BasicHttpBinding(),
            "/AutoService.svc"
        );
});

// ======================================================
// HABILITAR METADATOS WSDL
// ======================================================

var metadataBehavior =
    app.Services.GetRequiredService<ServiceMetadataBehavior>();

metadataBehavior.HttpGetEnabled = true;

// ======================================================
// RUTA PRINCIPAL DE PRUEBA
// ======================================================

app.MapGet("/", () =>
    "Servicio SOAP AutosSOAP funcionando correctamente.");

// ======================================================
// INICIAR APLICACIÓN
// ======================================================

app.Run();

