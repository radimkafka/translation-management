using TranslationManagement.Api.Models;
using TranslationManagement.Business.Dto;

namespace TranslationManagement.Api;

internal static class Mapping
{
    public static IEnumerable<TranslatorModel> ToModel(this IEnumerable<TranslatorDto> entity) => entity.Select(ToDto);

    public static TranslatorModel ToDto(this TranslatorDto entity) => new()
    {
        Id = entity.Id,
        CreditCardNumber = entity.CreditCardNumber,
        HourlyRate = entity.HourlyRate,
        Name = entity.Name,
        Status = entity.Status
    };

    public static AddTranslatorDto ToDto(this AddTranslatorModel entity) => new()
    {
        CreditCardNumber = entity.CreditCardNumber,
        HourlyRate = entity.HourlyRate,
        Name = entity.Name,
        Status = entity.Status
    };

}
