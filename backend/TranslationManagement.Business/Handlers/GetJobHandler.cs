using MediatR;
using Microsoft.EntityFrameworkCore;
using TranslationManagement.Business.Dto;
using TranslationManagement.Data;

namespace TranslationManagement.Business.Handlers;

public class GetJobHandler : IRequestHandler<GetJobs, JobDto[]>
{
    private readonly AppDbContext _appDbContext;

    public GetJobHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<JobDto[]> Handle(GetJobs request, CancellationToken cancellationToken)
    {  
        var data = await _appDbContext.TranslationJobs.ToArrayAsync(cancellationToken);
        return data.ToDto().ToArray();
    }
}
