using MediatR;
using TranslationManagement.Business.Dto;

namespace TranslationManagement.Business.Commands;

public record AddTranslator(AddTranslatorDto Translator) : IRequest<int>;
