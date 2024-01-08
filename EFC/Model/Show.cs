namespace EFC.Model;

public class Show
{
    public int Id { get; set; }
    public string Title { get; set; }
    public short Year { get; set; }
    public string Gerne { get; set; }
    
    public List<Episode> Episodes { get; set; }
}