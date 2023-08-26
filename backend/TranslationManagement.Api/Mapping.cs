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

    public static JobModel ToDto(this JobDto dto) => new()
    {
        Id = dto.Id,
        CustomerName = dto.CustomerName,
        OriginalContent = dto.OriginalContent,
        Price = dto.Price,
        Status = dto.Status,
        TranslatedContent = dto.TranslatedContent
    };

    public static AddJobDto ToDto(this AddJobModel model) => new()
    {
        CustomerName = model.CustomerName,
        OriginalContent = model.OriginalContent,
        Price = model.Price,
        TranslatedContent = model.TranslatedContent
    };

    public static UpdateJobStatusDto ToDto(this UpdateJobStatusModel model, int jobId) => new()
    {
        JobId = jobId,
        Status = (JobStatusDto)model.Status,
        TranslatorId = model.TranslatorId
    };
}
