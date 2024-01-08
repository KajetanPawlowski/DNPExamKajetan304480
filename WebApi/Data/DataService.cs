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
        //run out of time to implement
    }

    public Task<Project> GetProject(int projectId)
    {
        return Task.FromResult(projects.FirstOrDefault(p => p.Id == projectId));
    }

    public async Task<Project> CreateProject(CreateProjectDTO dto)
    {
        Project created = new()
        {
            Id = projects.Count,
            Title = dto.Title,
            ResponsibleName = dto.ResponsibleName,
            Status = dto.Status
        };
        foreach (var userStory in dto.UserStories)
        {
            AddUserStoryDTO dtoUS = new()
            {
                Description = userStory.Description,
                Estimate = userStory.Estimate,
                ProjectId = created.Id
            };
            await AddUserStory(dtoUS);
        }
        return created;
    }

    public async Task<Project> AddUserStory(AddUserStoryDTO dto)
    {
        UserStory story = new()
        {
            Id = userStories.Count,
            Description = dto.Description,
            Estimate = dto.Estimate
        };
        Project project = projects.FirstOrDefault(p => p.Id == dto.ProjectId);
        if (project == null)
        {
            throw new Exception();
        }
        project.UserStories.Add(story);
        return project;
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