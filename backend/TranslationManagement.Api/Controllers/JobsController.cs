using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TranslationManagement.Api.Controlers;
using TranslationManagement.Api.Models;
using TranslationManagement.Business;
using TranslationManagement.Business.Exceptions;
using ZadusApi.Web;

namespace TranslationManagement.Api.Controllers
{
    [ApiController]
    [NotCertifiedTranslatorExceptionFilter]
    [Route("api/jobs")]
    public class JobsController : ControllerBase
    {
        private readonly ILogger<TranslatorsController> _logger;
        private readonly IMediator _mediator;

        public JobsController(ILogger<TranslatorsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(JobModel[]))]
        public async Task<IActionResult> GetJobs(CancellationToken cancellationToken)
        {
            var data = await _mediator.Send(new GetJobs(), cancellationToken);
            return Ok(data.ToModel().ToArray());
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(int))]
        public async Task<IActionResult> CreateJob(AddJobModel job, CancellationToken cancellationToken)
        {
            var data = await _mediator.Send(new AddJob(job.ToDto()), cancellationToken);
            return Ok(data);
        }

        [HttpPost("file")]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(int))]
        public async Task<IActionResult> CreateJobWithFile(IFormFile file, string? customer, CancellationToken cancellationToken)
        {
            string? customerName;
            string? content;
            try
            {
                (customerName, content) = JobFileReader.Read(file);
            }
            catch (NotSupportedException e)
            {
                return BadRequest(e.Message);
            }
            if (string.IsNullOrEmpty(content))
            {
                var errors = new ModelStateDictionary();
                errors.AddModelError("Content", "Cannot be empty!");
                return BadRequest(errors);
            }
            if (string.IsNullOrEmpty(customerName) && string.IsNullOrEmpty(customer))
            {
                var errors = new ModelStateDictionary();
                errors.AddModelError(nameof(customer), "Cannot be empty!");
                return BadRequest(errors);
            }
            customerName ??= customer;
            var data = await _mediator.Send(new AddJob(new() { CustomerName = customerName!, OriginalContent = content }), cancellationToken);
            return Ok(data);
        }

        [HttpPut("{id}/status")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateJobStatus([FromRoute, Range(1, int.MaxValue)] int id, [FromBody] UpdateJobStatusModel jobStatusUpdate, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Job status update request received: {newStatus} for job {jobId} by translator {translatorId}", jobStatusUpdate.Status, id, jobStatusUpdate.TranslatorId);

            try
            {
                await _mediator.Send(new UpdateJobStatus(jobStatusUpdate.ToDto(id)), cancellationToken);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}