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
[Route("api/translators")]
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
    public async Task<IActionResult> GetTranslators([FromQuery] string? name, CancellationToken cancellationToken)
    {
        var data = await _mediator.Send(new GetTranslators(name), cancellationToken);
        return Ok(data.ToModel().ToArray());
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(int))]
    public async Task<IActionResult> AddTranslator(AddTranslatorModel translator, CancellationToken cancellationToken)
    {
        var data = await _mediator.Send(new AddTranslator(translator.ToDto()), cancellationToken);
        return Ok(data);
    }

    [HttpPut("{id}/status")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(int))]
    public async Task<IActionResult> UpdateTranslatorStatus([FromRoute, Range(1, int.MaxValue)] int id, [FromBody, Required] TranslatorStatusModel status, CancellationToken cancellationToken)
    {
        _logger.LogInformation("User status update request: {status} for user {id}", status, id.ToString());
        try
        {
            await _mediator.Send(new UpdateTranslatorStatus(id, (TranslatorStatusDto)status), cancellationToken);
            return Ok();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}