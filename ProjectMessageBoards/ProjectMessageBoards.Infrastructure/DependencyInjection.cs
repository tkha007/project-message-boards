using Microsoft.Extensions.DependencyInjection;
using ProjectMessageBoards.Application.Abstractions;
using ProjectMessageBoards.Infrastructure.Services;

namespace ProjectMessageBoards.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IProjectFeedService, ProjectFeedService>();
        services.AddSingleton<IUserSubscriptionService, UserSubscriptionService>();
        return services;
    }
}
