using MediatR;
using Microsoft.EntityFrameworkCore;
using TranslationManagement.Business.Dto;
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
        var job = await _appDbContext.TranslationJobs.FirstOrDefaultAsync(j => j.Id == request.Data.JobId, cancellationToken) ?? throw new NotFoundException();
        var isTranslatorCertifeid = await IsTranslatorCertifeid(request.Data.TranslatorId, cancellationToken);
        if (!isTranslatorCertifeid)
        {
            throw new NotCertifiedTranslatorException();
        }

        job.Status = request.Data.Status.ToString();
        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task<bool> IsTranslatorCertifeid(int translatorId, CancellationToken cancellationToken)
    {
        var translator = await _appDbContext.Translators.FirstOrDefaultAsync(a => a.Id == translatorId, cancellationToken) ?? throw new NotFoundException("Translator not found!");
        return Enum.TryParse<TranslatorStatusDto>(translator.Status, out var status) && status == TranslatorStatusDto.Certified;
    }
}
