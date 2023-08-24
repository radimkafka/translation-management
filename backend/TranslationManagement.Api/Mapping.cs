using TranslationManagement.Api.Models;
using TranslationManagement.Business.Dto;
using TranslationManagement.Data.Entities;

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

}
