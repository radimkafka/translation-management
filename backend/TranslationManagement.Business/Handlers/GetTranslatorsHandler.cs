using MediatR;
using Microsoft.EntityFrameworkCore;
using TranslationManagement.Business.Dto;
using TranslationManagement.Business.Queries;
using TranslationManagement.Data.Entities;

namespace TranslationManagement.Business.Handlers;

public class GetTranslatorsHandler : IRequestHandler<GetTranslators, TranslatorDto>
{
    private readonly AppDbContext _appDbContext;

    public GetTranslatorsHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Translator> Handle(GetTranslators request, CancellationToken cancellationToken)
    {
        var data = await _appDbContext.Translators.ToArrayAsync(cancellationToken);
        return data;
    }
}
