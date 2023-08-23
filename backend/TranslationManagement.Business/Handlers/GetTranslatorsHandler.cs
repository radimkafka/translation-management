using MediatR;
using TranslationManagement.Business.Dto;
using TranslationManagement.Business.Queries;

namespace TranslationManagement.Business.Handlers;

public class GetTranslatorsHandler : IRequestHandler<GetTranslators, TranslatorDto>
{
    public Task<TranslatorDto> Handle(GetTranslators request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
