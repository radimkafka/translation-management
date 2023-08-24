using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using External.ThirdParty.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TranslationManagement.Api.Controlers;
using TranslationManagement.Api.Models;
using TranslationManagement.Business;
using TranslationManagement.Data;
using TranslationManagement.Data.Entities;

namespace TranslationManagement.Api.Controllers
{
    [ApiController]
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
        public async Task<IActionResult> GetJobs()
        {
            var data = await _mediator.Send(new GetJobs());
            return Ok(data.ToModel().ToArray());
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(int))]
        public async Task<IActionResult> CreateJob(AddJobModel job)
        {
            var data = await _mediator.Send(new AddJob(job.ToDto()));
            return Ok(data);
        }

        [HttpPost("file")]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(int))]
        public async Task<IActionResult> CreateJobWithFile(IFormFile file, string? customer)
        {
            string? customerName;
            string content;
            try
            {
                (customerName, content) = JobFileReader.Read(file);
            }
            catch (NotSupportedException e)
            {
                return BadRequest(e.Message);
            }
            if (string.IsNullOrEmpty(customerName) && string.IsNullOrEmpty(customer))
            {
                var errors = new ModelStateDictionary();
                errors.AddModelError(nameof(customer), "Cannot be empty!");
                return BadRequest(errors);
            }
            customerName ??= customer;
            var data = await _mediator.Send(new AddJob(new() { CustomerName = customerName!, OriginalContent = content }));
            return Ok(data);
        }

        [HttpPut]
        public string UpdateJobStatus(int jobId, int translatorId, string newStatus = "")
        {
            throw new NotImplementedException();
            /*
            _logger.LogInformation("Job status update request received: " + newStatus + " for job " + jobId.ToString() + " by translator " + translatorId);
            if (typeof(JobStatuses).GetProperties().Count(prop => prop.Name == newStatus) == 0)
            {
                return "invalid status";
            }

            var job = _context.TranslationJobs.Single(j => j.Id == jobId);

            bool isInvalidStatusChange = (job.Status == JobStatuses.New && newStatus == JobStatuses.Completed) ||
                                         job.Status == JobStatuses.Completed || newStatus == JobStatuses.New;
            if (isInvalidStatusChange)
            {
                return "invalid status change";
            }

            job.Status = newStatus;
            _context.SaveChanges();
            return "updated";*/
        }
    }
}