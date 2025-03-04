using ProjectMessageBoards.Application.Abstractions;
using ProjectMessageBoards.Domain;

namespace ProjectMessageBoards.Infrastructure.Services;

internal sealed class UserSubscriptionService : IUserSubscriptionService
{
    private Dictionary<User, List<Project>> _userSubscriptions = [];

    public void Subscribe(User user, Project project)
    {
        if (_userSubscriptions.ContainsKey(user))
        {
            _userSubscriptions[user].Add(project);
        }
        else
        {
            _userSubscriptions.Add(user, [project]);
        }
    }

    public List<Project> ListProjectsForUser(User user)
    {
        return _userSubscriptions[user] ?? [];
    }
}
