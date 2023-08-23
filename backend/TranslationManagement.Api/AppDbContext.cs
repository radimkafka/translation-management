﻿using Microsoft.EntityFrameworkCore;
using TranslationManagement.Api.Controllers;
using TranslationManagement.Api.Models;

namespace TranslationManagement.Api;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TranslationJobController.TranslationJob> TranslationJobs { get; set; }
    public DbSet<TranslatorModel> Translators { get; set; }
}