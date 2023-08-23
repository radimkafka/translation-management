﻿using System;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TranslationManagement.Api.Models;
using TranslationManagement.Business.Queries;

namespace TranslationManagement.Api.Controlers;

[ApiController]
[Route("api/TranslatorsManagement/[action]")]
public class TranslatorManagementController : ControllerBase
{
    public static readonly string[] TranslatorStatuses = { "Applicant", "Certified", "Deleted" };

    private readonly ILogger<TranslatorManagementController> _logger;
    private readonly IMediator mediator;
    private AppDbContext _context;

    public TranslatorManagementController(IServiceScopeFactory scopeFactory, ILogger<TranslatorManagementController> logger, IMediator mediator)
    {
        _context = scopeFactory.CreateScope().ServiceProvider.GetService<AppDbContext>();
        _logger = logger;
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<TranslatorModel[]> GetTranslators()
    {        
        return _context.Translators.ToArray();
    }

    [HttpGet]
    public TranslatorModel[] GetTranslatorsByName(string name)
    {
        return _context.Translators.Where(t => t.Name == name).ToArray();
    }

    [HttpPost]
    public bool AddTranslator(TranslatorModel translator)
    {
        _context.Translators.Add(translator);
        return _context.SaveChanges() > 0;
    }
    
    [HttpPost]
    public string UpdateTranslatorStatus(int Translator, string newStatus = "")
    {
        _logger.LogInformation("User status update request: " + newStatus + " for user " + Translator.ToString());
        if (TranslatorStatuses.Where(status => status == newStatus).Count() == 0)
        {
            throw new ArgumentException("unknown status");
        }

        var job = _context.Translators.Single(j => j.Id == Translator);
        job.Status = newStatus;
        _context.SaveChanges();

        return "updated";
    }
}