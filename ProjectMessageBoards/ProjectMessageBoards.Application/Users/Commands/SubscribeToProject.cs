using ProjectMessageBoards.Application.Abstractions;
using ProjectMessageBoards.Domain;

namespace ProjectMessageBoards.Application.Users.Commands;

public sealed class SubscribeToProject(IUserSubscriptionService userSubscriptionService)
{
    public void Subscribe(string userName, string projectName)
    {
        var user = new User(userName);
        var project = new Project(projectName);

        userSubscriptionService.Subscribe(user, project);
    }
}
