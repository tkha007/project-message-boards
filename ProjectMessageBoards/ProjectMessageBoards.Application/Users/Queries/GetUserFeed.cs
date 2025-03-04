using ProjectMessageBoards.Application.Abstractions;
using ProjectMessageBoards.Domain;
using System.Text;

namespace ProjectMessageBoards.Application.Users.Queries;

public sealed class GetUserFeed(IUserSubscriptionService userSubscriptionService, IProjectFeedService projectFeedService)
{
    public string Feed(string userName)
    {
        var user = new User(userName);
        var projects = userSubscriptionService.ListProjectsForUser(user);

        var projectFeed = projectFeedService.GetAllMessagesForProjects(projects);

        var feedBuilder = new StringBuilder();
        foreach (var (project, message) in projectFeed)
        {
            feedBuilder.AppendLine($"{project} - {message.User.Name}: {message.Content} ({(DateTime.UtcNow - message.PostDateUtc).TotalMinutes} minutes ago)");
        }

        return feedBuilder.ToString();
    }
}
