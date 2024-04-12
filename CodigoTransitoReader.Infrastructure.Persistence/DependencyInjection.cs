using CodigoTransitoReader.Domain.Abstractions;
using CodigoTransitoReader.Domain.Files.Repositories;
using CodigoTransitoReader.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodigoTransitoReader.Infrastructure.Persistence;

public class Unit : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}


public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IFileRepository, FileRepository>();
        services.AddScoped<IUnitOfWork, Unit>();

        return services;
    }
}