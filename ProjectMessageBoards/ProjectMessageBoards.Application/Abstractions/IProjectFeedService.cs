using ProjectMessageBoards.Domain;

namespace ProjectMessageBoards.Application.Abstractions;

public interface IProjectFeedService
{
    void AddMessage(Project project, Message message);
    List<Message> GetAllMessagesForProject(Project project);
    List<(Project, Message)> GetAllMessagesForProjects(List<Project> projects);
}
