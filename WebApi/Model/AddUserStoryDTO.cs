namespace WebApi.Model;

public class AddUserStoryDTO
{
    public int ProjectId { get; set; }
    public string Description { get; set; }
    public string Estimate { get; set; }
}