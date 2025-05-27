using Cine.Resenha.Persistence.DatabaseContext;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Resenha.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<MovieDatabaseContext>();
        return services;
    }
}