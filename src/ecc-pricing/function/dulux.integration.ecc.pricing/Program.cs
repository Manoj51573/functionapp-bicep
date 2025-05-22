using dulux.integration.ecc.models.Configurations;
using dulux.integration.ecc.services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);
builder.ConfigureFunctionsWebApplication();
// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4
builder.Services
   .AddApplicationInsightsTelemetryWorkerService()
   .ConfigureFunctionsApplicationInsights();
builder.Services.AddHttpClient(); // Default HttpClient
builder.Services
   .AddSingleton<IPriceLookupService, PriceLookupService>()
   .AddOptions<SapEccOption>()
       .Configure<IConfiguration>((sapEccOption, configuration) =>
           configuration.GetSection(nameof(SapEccOption)).Bind(sapEccOption));
builder.Services.AddHttpClient("UnsafeClient", client =>
{
    client.Timeout = TimeSpan.FromSeconds(60); // Adjust as needed
})
.ConfigurePrimaryHttpMessageHandler(() =>
{
    return new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    };
});
builder.Build().Run();


