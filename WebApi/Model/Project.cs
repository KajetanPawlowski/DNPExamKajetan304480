namespace WebApi.Model;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool Status { get; set; }
    public string ResponsibleName { get; set; }
    public List<UserStory> UserStories { get; set; }
}