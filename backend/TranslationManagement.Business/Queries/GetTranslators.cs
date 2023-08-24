using MediatR;
using TranslationManagement.Business.Dto;

namespace TranslationManagement.Business.Queries;

public record class GetTranslators(string? Name = null) : IRequest<TranslatorDto[]>;

