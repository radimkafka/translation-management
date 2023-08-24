using TranslationManagement.Business.Dto;
using TranslationManagement.Data.Entities;

namespace TranslationManagement.Business;

internal static class Mapping
{
    public static IEnumerable<TranslatorDto> ToDto(this IEnumerable<Translator> entity) => entity.Select(ToDto);

    public static TranslatorDto ToDto(this Translator entity) => new()
    {
        Id = entity.Id,
        CreditCardNumber = entity.CreditCardNumber,
        HourlyRate = entity.HourlyRate,
        Name = entity.Name,
        Status = entity.Status
    };
    public static Translator  ToEntity(this AddTranslatorDto dto) => new()
    {
        CreditCardNumber = dto.CreditCardNumber,
        HourlyRate = dto.HourlyRate,
        Name = dto.Name,
        Status = dto.Status
    };

}
