using WebApi.Model;

namespace WebApi.Data;

public interface IDataService
{
    Task<List<Project>> GetAllProjects(SearchProjectsDTO dto);
    Task<Project> GetProject(int projectId);
    Task<Project> CreateProject(CreateProjectDTO dto);
    Task<Project> AddUserStory(AddUserStoryDTO dto);
    
}