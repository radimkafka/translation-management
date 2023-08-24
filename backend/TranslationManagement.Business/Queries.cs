using MediatR;
using TranslationManagement.Business.Dto;

namespace TranslationManagement.Business;

public record class GetTranslators(string? Name = null) : IRequest<TranslatorDto[]>;
public record class GetJobs() : IRequest<JobDto[]>;
