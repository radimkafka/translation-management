using MediatR;
using Microsoft.EntityFrameworkCore;
using TranslationManagement.Business.Exceptions;
using TranslationManagement.Data;

namespace TranslationManagement.Business.Handlers;

public class UpdateJobStatusHandler : IRequestHandler<UpdateJobStatus>
{
    private readonly AppDbContext _appDbContext;

    public UpdateJobStatusHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Handle(UpdateJobStatus request, CancellationToken cancellationToken)
    {
        var job = await _appDbContext.TranslationJobs.FirstOrDefaultAsync(j => j.Id == request.JobStatusDto.JobId, cancellationToken) ?? throw new NotFoundException();

        job.Status = request.JobStatusDto.Status.ToString();
        await _appDbContext.SaveChangesAsync(cancellationToken);
    }
}
