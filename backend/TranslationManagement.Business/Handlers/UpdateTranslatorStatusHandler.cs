using MediatR;
using Microsoft.EntityFrameworkCore;
using TranslationManagement.Business.Exceptions;
using TranslationManagement.Data;

namespace TranslationManagement.Business.Handlers;

public class UpdateTranslatorStatusHandler : IRequestHandler<UpdateJobStatus>
{
    private readonly AppDbContext _appDbContext;

    public UpdateTranslatorStatusHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Handle(UpdateJobStatus request, CancellationToken cancellationToken)
    {
        var entity = await _appDbContext.TranslationJobs.FirstOrDefaultAsync(a => a.Id == request.Data.JobId, cancellationToken) ?? throw new NotFoundException();
        entity.Status = request.Data.Status.ToString();
        await _appDbContext.SaveChangesAsync(cancellationToken);
    }
}
