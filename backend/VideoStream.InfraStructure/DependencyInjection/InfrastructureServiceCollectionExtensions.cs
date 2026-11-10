using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VideoStream.InfraStructure.Persistence;

namespace VideoStream.InfraStructure.DependencyInjection;

public static class InfraStructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);

        services.AddDbContext<VideoStreamDbContext>(options =>
            options.UseNpgsql(connectionString));

            return services;
    }
}