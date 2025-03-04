// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using ProjectMessageBoards.Application;
using ProjectMessageBoards.Application.Projects.Queries;
using ProjectMessageBoards.Application.Users.Commands;
using ProjectMessageBoards.Application.Users.Queries;
using ProjectMessageBoards.Infrastructure;

var serviceCollection = new ServiceCollection();
var serviceProvider = serviceCollection
    .RegisterInfrastructureServices()
    .RegisterApplicationServices()
    .BuildServiceProvider();

string? command;
do
{
    Console.Write("(type EXIT to quit) > ");
    command = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(command))
    {
        ProcessCommand(command, serviceProvider);
    }
} while (command is not null && !command.Equals("exit", StringComparison.OrdinalIgnoreCase));

static void ProcessCommand(string arguments, IServiceProvider serviceProvider)
{
    if (!string.IsNullOrWhiteSpace(arguments))
    {
        var parts = arguments.Split(" ");
        if (parts.Length == 1)
        {
            // Project feed
            var projectName = parts[0];
            var service = serviceProvider.GetRequiredService<GetProjectFeed>();
            ProjectFeed(service, projectName);
        }
        else if (parts.Length == 2)
        {
            // User feed
            var userName = parts[0];
            var service = serviceProvider.GetRequiredService<GetUserFeed>();
            UserFeed(service, userName);
        }
        else if (parts.Length == 3)
        {
            // Subscribe to project
            var userName = parts[0];
            var projectName = parts[2];
            var service = serviceProvider.GetRequiredService<SubscribeToProject>();
            SubscribeToProject(service, userName, projectName);
        }
        else
        {
            // Post to project
            var userName = parts[0];
            var projectName = parts[2];
            var message = parts[3];
            var service = serviceProvider.GetRequiredService<PostToProject>();
            PostToProject(service, userName, projectName, message);
        }
    }
}

static void ProjectFeed(GetProjectFeed projectFeed, string projectName)
{
    Console.WriteLine(projectFeed.Feed(projectName));
}

static void UserFeed(GetUserFeed userFeed, string userName)
{
    Console.WriteLine(userFeed.Feed(userName));
}

static void SubscribeToProject(SubscribeToProject subscribeToProject, string userName, string projectName)
{
    subscribeToProject.Subscribe(userName, projectName);
}

static void PostToProject(PostToProject postToProject, string userName, string projectName, string message)
{
    postToProject.Post(userName, projectName, message);
}