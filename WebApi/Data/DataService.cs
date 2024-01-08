using System.Text.Json;
using WebApi.Model;

namespace WebApi.Data;

public class DataService : IDataService
{
    private List<Project> projects;
    private List<UserStory> userStories;

    public DataService()
    {
        projects = new List<Project>();
        userStories = new List<UserStory>();
        CreateDummyProjects(5);
    }
    
    public Task<List<Project>> GetAllProjects(SearchProjectsDTO dto)
    {
        return Task.FromResult(projects);
    }

    public Task<Project> GetProject(int projectId)
    {
        throw new NotImplementedException();
    }

    public Task<Project> CreateProject(CreateProjectDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<Project> AddUserStory(AddUserStoryDTO dto)
    {
        throw new NotImplementedException();
    }
    private void CreateDummyProjects(int count)
    {
        Random random = new Random();
        string[] names = new[] { "Kajetan", "Maja", "Ariana", "Rado" };
        string[] titles = new[] { "Armagedon", "DNP Exam", "SEP Project", "Snow everywhere" };
        string[] bodies = new[] { "that is a long mail body", "somethong writen here" };
        for (int i = 0; i < count; i++)
        {
            Project next = new()
            {
                Id = projects.Count,
                Title = titles[random.Next(0,3)],
                Status = false,
                ResponsibleName = names[random.Next(0,3)],
                UserStories = CreateDummyUserStories(random.Next(3,10))
            };
            projects.Add(next);
        }
    }
    private List<UserStory> CreateDummyUserStories(int count)
    {
        Random random = new Random();
        string[] names = new[] { "Kajetan", "Maja", "Ariana", "Rado" };
        string[] titles = new[] { "Armagedon", "DNP Exam", "SEP Project", "Snow everywhere" };
        string[] bodies = new[] { "that is a long mail body", "somethong writen here" };
        List<UserStory> result = new List<UserStory>();
        for (int i = 0; i < count; i++)
        {
            UserStory next = new()
            {
                Id = userStories.Count,
                Description = titles[random.Next(0,3)],
                Estimate = bodies[random.Next(1)]
            };
            userStories.Add(next);
            result.Add(next);
        }

        return result;
    }
}