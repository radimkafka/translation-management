using MediatR;
using TranslationManagement.Business.Dto;

namespace TranslationManagement.Business;

public record AddTranslator(AddTranslatorDto Translator) : IRequest<int>;
public record UpdateTranslatorStatus(int TranslatorId, TranslatorStatusDto Status) : IRequest;
