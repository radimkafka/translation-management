using External.ThirdParty.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using TranslationManagement.Business.Dto;
using TranslationManagement.Data;

namespace TranslationManagement.Business.Handlers;

public class AddJobHandler : IRequestHandler<AddJob, int>
{
    private readonly AppDbContext _appDbContext;
    private readonly INotificationService _notificationService;
    private readonly ILogger<AddJobHandler> _logger;

    public AddJobHandler(AppDbContext appDbContext, INotificationService notificationService, ILogger<AddJobHandler> logger)
    {
        _appDbContext = appDbContext;
        _notificationService = notificationService;
        _logger = logger;
    }

    public async Task<int> Handle(AddJob request, CancellationToken cancellationToken)
    {
        var entity = request.Job.ToEntity();
        entity.Status = JobStatusDto.New.ToString();
        _appDbContext.TranslationJobs.Add(entity);
        var result = await _appDbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            await SendNewJobNotificationWithRetry(entity.Id);
            return entity.Id;
        }
        throw new Exception("server error");
    }

    private async Task SendNewJobNotificationWithRetry(int jobId)
    {
        bool success = default;
        do
        {
            try
            {
                success = await _notificationService.SendNotification($"Job created: {jobId}");
            }
            catch (ApplicationException e)
            {
                _logger.LogWarning("Sending notification for new job {id} failed. {Reason}", jobId, e.Message);
            }
        } while (!success);
        _logger.LogInformation("Notification for new job {id} sent", jobId);
    }
}
