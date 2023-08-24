using System.ComponentModel.DataAnnotations;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TranslationManagement.Api.Models;
using TranslationManagement.Business;
using TranslationManagement.Business.Dto;
using TranslationManagement.Business.Exceptions;

namespace TranslationManagement.Api.Controlers;

[ApiController]
[Route("api/Translators")]
public class TranslatorsController : ControllerBase
{

    private readonly ILogger<TranslatorsController> _logger;
    private readonly IMediator _mediator;

    public TranslatorsController(ILogger<TranslatorsController> logger, IMediator mediator)
    {
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

    [HttpPut("Status/{id:min(1)}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(int))]
    public async Task<IActionResult> UpdateTranslatorStatus([FromRoute] int id, [FromBody, Required] TranslatorStatusModel status)
    {
        _logger.LogInformation("User status update request: {status} for user {id}", status, id.ToString());
        try
        {
            await _mediator.Send(new UpdateTranslatorStatus(id, (TranslatorStatusDto)status));
            return Ok();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}