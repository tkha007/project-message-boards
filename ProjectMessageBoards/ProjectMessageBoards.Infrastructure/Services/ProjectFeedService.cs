using ProjectMessageBoards.Application.Abstractions;
using ProjectMessageBoards.Domain;

namespace ProjectMessageBoards.Infrastructure.Services;

internal sealed class ProjectFeedService : IProjectFeedService
{
    private Dictionary<Project, List<Message>> _projectFeed = [];

    public void AddMessage(Project project, Message message)
    {
        if (_projectFeed.ContainsKey(project))
        {
            _projectFeed[project].Add(message);
        } else
        {
            _projectFeed.Add(project, [message]);
        }
    }

    public List<Message> GetAllMessagesForProject(Project project)
    {
        return _projectFeed[project].OrderByDescending(x => x.PostDateUtc).ToList();
    }

    public List<(Project, Message)> GetAllMessagesForProjects(List<Project> projects)
    {
        return _projectFeed.SelectMany(x => x.Value, (project, message) => (Project: project.Key, Message: message)).OrderByDescending(x => x.Message.PostDateUtc).ToList();
    }
}
