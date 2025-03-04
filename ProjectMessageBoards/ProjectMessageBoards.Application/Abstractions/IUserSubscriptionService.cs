using ProjectMessageBoards.Domain;

namespace ProjectMessageBoards.Application.Abstractions;

public interface IUserSubscriptionService
{
    void Subscribe(User user, Project project);
    List<Project> ListProjectsForUser(User user);
}
