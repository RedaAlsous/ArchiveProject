
using Archive.Domain.Entites;
using Archive.Domain.Repositories;
using Archive.Infrastructure.Presistence;
using Archive.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Archive.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AechiveDB");
        services.AddDbContext<ArchiveProjectDbContext>(options =>
        options.UseSqlServer(connectionString)
        .EnableSensitiveDataLogging());

        services.AddIdentityApiEndpoints<User>()
            .AddEntityFrameworkStores<ArchiveProjectDbContext>();

        services.AddScoped<IFolderRepositories, FolderRepository>();
        services.AddScoped<IFileRepository, FileRepository>();
        services.AddScoped<ISharedItemRepository, SharedItemRepository>();
    }
}
