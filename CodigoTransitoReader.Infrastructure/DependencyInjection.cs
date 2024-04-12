using CodigoTransitoReader.Application.Abstractions.Clock;
using CodigoTransitoReader.Application.Abstractions.IA;
using CodigoTransitoReader.Infrastructure.Clock;
using CodigoTransitoReader.Infrastructure.Configurations;
using CodigoTransitoReader.Infrastructure.IA;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Refit;

namespace CodigoTransitoReader.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ChatPdfConfiguration>(opt => configuration.GetSection("ChatPDF").Bind(opt));
        services.AddOptions<ChatPdfConfiguration>();

        services.AddRefitClient<IChatPdfApi>()
            .ConfigureHttpClient((sp, client) =>
            {
                var config = sp.GetRequiredService<IOptions<ChatPdfConfiguration>>();
                client.BaseAddress = new Uri(config.Value.BaseUrl);
                client.DefaultRequestHeaders.Add("x-api-key", config.Value.ApiKey);
            });

        services.AddScoped<IChatPdfService, ChatPdfService>();
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}