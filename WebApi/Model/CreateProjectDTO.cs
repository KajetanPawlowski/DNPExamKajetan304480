namespace WebApi.Model;

public class CreateProjectDTO
{
    public string Title { get; set; }
    public bool Status { get; set; }
    public string ResponsibleName { get; set; }
    public List<UserStoryWithoutId> UserStories { get; set; }
    
    public class UserStoryWithoutId
    {
        public string Description { get; set; }
        public string Estimate { get; set; }
    }
}