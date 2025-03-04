using ProjectMessageBoards.Application.Abstractions;
using ProjectMessageBoards.Domain;

namespace ProjectMessageBoards.Application.Users.Commands;

public sealed class PostToProject(IProjectFeedService projectFeedService)
{
    public void Post(string userName, string projectName, string message)
    {
        var user = new User(userName);
        var project = new Project(projectName);
        var newMessage = new Message(user, message.Trim(), DateTime.UtcNow);

        projectFeedService.AddMessage(project, newMessage);
    }
}
