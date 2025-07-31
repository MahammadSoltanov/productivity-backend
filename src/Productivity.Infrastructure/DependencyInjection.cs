using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Productivity.Application.Common.Interfaces.Authentication;
using Productivity.Infrastructure.Authentication;
using Productivity.Infrastructure.Persistence;

namespace Productivity.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddDbContext<ProductivityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("LocalConnection")));

        return services;
    }
}
