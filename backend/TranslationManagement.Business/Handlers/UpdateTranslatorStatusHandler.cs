using MediatR;
using Microsoft.EntityFrameworkCore;
using TranslationManagement.Business.Exceptions;
using TranslationManagement.Data;

namespace TranslationManagement.Business.Handlers;

public class UpdateTranslatorStatusHandler : IRequestHandler<UpdateTranslatorStatus>
{
    private readonly AppDbContext _appDbContext;

    public UpdateTranslatorStatusHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Handle(UpdateTranslatorStatus request, CancellationToken cancellationToken)
    {
        var entity = await _appDbContext.Translators.FirstOrDefaultAsync(a => a.Id == request.TranslatorId, cancellationToken) ?? throw new NotFoundException();
        entity.Status = request.Status.ToString();
        await _appDbContext.SaveChangesAsync(cancellationToken);
    }
}
