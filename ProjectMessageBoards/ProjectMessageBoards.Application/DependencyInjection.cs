using Microsoft.Extensions.DependencyInjection;
using ProjectMessageBoards.Application.Projects.Queries;
using ProjectMessageBoards.Application.Users.Commands;
using ProjectMessageBoards.Application.Users.Queries;

namespace ProjectMessageBoards.Application;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<GetProjectFeed>();
        services.AddScoped<PostToProject>();
        services.AddScoped<SubscribeToProject>();
        services.AddScoped<GetUserFeed>();
        return services;
    }
}
