using Microsoft.EntityFrameworkCore;
using TranslationManagement.Data.Entities;

namespace TranslationManagement.Data;

public class AppDbContext : DbContext
{
    public AppDbContext() : base()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Job> TranslationJobs { get; set; }
    public virtual DbSet<Translator> Translators { get; set; }
}