using EFC;
using EFC.Model;

var dataContext = new EFC.AppContext();

List<Episode> makeEpisotes(int count, Show show)
{
    List<Episode> result = new List<Episode>();
    for (int i = 0; i < count; i++)
    {
        Episode created = new()
        {
            Runtime = 2000,
            Show = show,
            Title = "Episote" + i,
            SeasonEpisode = "S01E0" + i
        };
        result.Add(created);
    }

    return result;
}
Show next = new()
{
    Title = "DNP Class",
    Gerne = "Comedy",
    Year = 2023
};
next.Episodes = makeEpisotes(5, next);
dataContext.Shows.Add(next);