using Microsoft.EntityFrameworkCore;
using TranslationManagement.Data.Entities;

namespace TranslationManagement.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TranslationJob> TranslationJobs { get; set; }
    public DbSet<Translator> Translators { get; set; }
}