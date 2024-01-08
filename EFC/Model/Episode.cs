namespace EFC.Model;

public class Episode
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Runtime { get; set; }
    public string SeasonEpisode { get; set; }
    
    public int ShowId { get; set; }
    public Show Show { get; set; }
}