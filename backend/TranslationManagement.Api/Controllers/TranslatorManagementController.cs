using System.ComponentModel.DataAnnotations;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TranslationManagement.Api.Models;
using TranslationManagement.Business.Commands;
using TranslationManagement.Business.Queries;
using TranslationManagement.Data;

namespace TranslationManagement.Api.Controlers;

[ApiController]
[Route("api/TranslatorsManagement/Translators")]
public class TranslatorManagementController : ControllerBase
{

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

    [HttpPut("Status/{id}")]
    public string UpdateTranslatorStatus([FromRoute] int id, [FromBody, Required] TranslatorStatusModel status)
    {
        throw new NotImplementedException();
        //_logger.LogInformation("User status update request: {status} for user {id}", status, id.ToString());

        //var job = _context.Translators.Single(j => j.Id == id);
        //job.Status = status;
        //_context.SaveChanges();

        //return "updated";
    }
}