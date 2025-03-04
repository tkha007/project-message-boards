using ProjectMessageBoards.Application.Abstractions;
using ProjectMessageBoards.Domain;
using System.Text;

namespace ProjectMessageBoards.Application.Projects.Queries;

public sealed class GetProjectFeed(IProjectFeedService projectFeedService)
{
    public string Feed(string projectName)
    {
        var project = new Project(projectName);
        var messages = projectFeedService.GetAllMessagesForProject(project);

        var feedBuilder = new StringBuilder();
        foreach (var message in messages)
        {
            feedBuilder.AppendLine(message.User.Name);
            feedBuilder.AppendLine($"{message.Content} ({(DateTime.UtcNow - message.PostDateUtc).TotalMinutes} minutes ago)");
        }

        return feedBuilder.ToString();
    }
}
