using EFC.Model;
using Microsoft.EntityFrameworkCore;

namespace EFC;

public class AppContext : DbContext
{
    public DbSet<Show> Shows { get; set; }
    public DbSet<Episode> Episodes { get; set; }
    
    public string DbPath { get; }

    public AppContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "304480Exam.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); 
    }
}