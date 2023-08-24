using System;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TranslationManagement.Api.Models;
using TranslationManagement.Business.Commands;
using TranslationManagement.Business.Queries;
using TranslationManagement.Data;

namespace TranslationManagement.Api.Controlers;

[ApiController]
[Route("api/TranslatorsManagement/Translators")]
public class TranslatorManagementController : ControllerBase
{
    public static readonly string[] TranslatorStatuses = { "Applicant", "Certified", "Deleted" };

    private readonly ILogger<TranslatorManagementController> _logger;
    private readonly IMediator _mediator;
    private AppDbContext _context;

    public TranslatorManagementController(IServiceScopeFactory scopeFactory, ILogger<TranslatorManagementController> logger, IMediator mediator)
    {
        _context = scopeFactory.CreateScope().ServiceProvider.GetService<AppDbContext>();
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(TranslatorModel[]))]
    public async Task<IActionResult> GetTranslators([FromQuery] string? name)
    {
        var data = await _mediator.Send(new GetTranslators(name));
        return Ok(data.ToModel().ToArray());
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(int))]
    public async Task<IActionResult> AddTranslator(AddTranslatorModel translator)
    {
        var data = await _mediator.Send(new AddTranslator(translator.ToDto()));
        return Ok(data);
    }

    [HttpPut("Status")]
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