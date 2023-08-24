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
        Status = Enum.Parse<TranslatorStatusDto>(entity.Status)
    };
    public static Translator ToEntity(this AddTranslatorDto dto) => new()
    {
        CreditCardNumber = dto.CreditCardNumber,
        HourlyRate = dto.HourlyRate,
        Name = dto.Name,
        Status = dto.Status.ToString()
    };

    public static IEnumerable<JobDto> ToDto(this IEnumerable<Job> entity) => entity.Select(ToDto);

    public static JobDto ToDto(this Job entity) => new()
    {
        Id = entity.Id,
        CustomerName = entity.CustomerName,
        OriginalContent = entity.OriginalContent,
        Price = entity.Price,
        Status = entity.Status,
        TranslatedContent = entity.TranslatedContent
    };

    public static Job ToEntity(this AddJobDto dto) => new()
    {
        CustomerName = dto.CustomerName,
        OriginalContent = dto.OriginalContent,
        Price = dto.Price,
        TranslatedContent = dto.TranslatedContent
    };

}
