using MediatR;
using TranslationManagement.Data;

namespace TranslationManagement.Business.Handlers;

public class AddTranslatorHandler : IRequestHandler<AddTranslator, int>
{
    private readonly AppDbContext _appDbContext;

    public AddTranslatorHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> Handle(AddTranslator request, CancellationToken cancellationToken)
    {
        var entity = request.Translator.ToEntity();
        _appDbContext.Translators.Add(entity);
        await _appDbContext.SaveChangesAsync(cancellationToken);        
        return entity.Id;
    }
}
