using MediatR;
using Microsoft.EntityFrameworkCore;
using TranslationManagement.Business.Dto;
using TranslationManagement.Business.Queries;
using TranslationManagement.Data;

namespace TranslationManagement.Business.Handlers;

public class GetTranslatorsHandler : IRequestHandler<GetTranslators, TranslatorDto[]>
{
    private readonly AppDbContext _appDbContext;

    public GetTranslatorsHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<TranslatorDto[]> Handle(GetTranslators request, CancellationToken cancellationToken)
    {
        var query = _appDbContext.Translators.AsQueryable();
        if (!string.IsNullOrEmpty(request.Name))
        {
            query = query.Where(a => a.Name == request.Name);
        }
        var data = await query.ToArrayAsync(cancellationToken);
        return data.ToDto().ToArray();
    }
}
