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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TranslationManagement.Api.Controlers;
using TranslationManagement.Api.Models;
using TranslationManagement.Business;
using TranslationManagement.Data;

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

        const double PricePerCharacter = 0.01;
        private void SetPrice(JobModel job)
        {
            job.Price = job.OriginalContent.Length * PricePerCharacter;
        }

        [HttpPost]
        public bool CreateJob(JobModel job)
        {
            throw new NotImplementedException();
            //job.Status = "New";
            //SetPrice(job);
            //_context.TranslationJobs.Add(job);
            //bool success = _context.SaveChanges() > 0;
            //if (success)
            //{
            //    var notificationSvc = new UnreliableNotificationService();
            //    while (!notificationSvc.SendNotification("Job created: " + job.Id).Result)
            //    {
            //    }

            //    _logger.LogInformation("New job notification sent");
            //}

            //return success;
        }

        [HttpPost("file")]
        public bool CreateJobWithFile(IFormFile file, string customer)
        {
            var reader = new StreamReader(file.OpenReadStream());
            string content;

            if (file.FileName.EndsWith(".txt"))
            {
                content = reader.ReadToEnd();
            }
            else if (file.FileName.EndsWith(".xml"))
            {
                var xdoc = XDocument.Parse(reader.ReadToEnd());
                content = xdoc.Root.Element("Content").Value;
                customer = xdoc.Root.Element("Customer").Value.Trim();
            }
            else
            {
                throw new NotSupportedException("unsupported file");
            }

            var newJob = new JobModel()
            {
                OriginalContent = content,
                TranslatedContent = "",
                CustomerName = customer,
            };

            SetPrice(newJob);

            return CreateJob(newJob);
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