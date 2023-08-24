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
        Status = (TranslatorStatusModel)entity.Status
    };

    public static AddTranslatorDto ToDto(this AddTranslatorModel entity) => new()
    {
        CreditCardNumber = entity.CreditCardNumber,
        HourlyRate = entity.HourlyRate,
        Name = entity.Name,
        Status = (TranslatorStatusDto)entity.Status
    };

    public static IEnumerable<JobModel> ToModel(this IEnumerable<JobDto> entity) => entity.Select(ToDto);

    public static JobModel ToDto(this JobDto entity) => new()
    {
        Id = entity.Id,
        CustomerName = entity.CustomerName,
        OriginalContent = entity.OriginalContent,
        Price = entity.Price,
        Status = entity.Status,
        TranslatedContent = entity.TranslatedContent
    };

    public static AddJobDto ToDto(this AddJobModel entity) => new()
    {
        CustomerName = entity.CustomerName,
        OriginalContent = entity.OriginalContent,
        Price = entity.Price,        
        TranslatedContent = entity.TranslatedContent
    };
}
