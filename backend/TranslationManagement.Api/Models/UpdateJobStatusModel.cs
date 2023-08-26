namespace TranslationManagement.Api.Models;

public class UpdateJobStatusModel
{
    public int TranslatorId { get; set; }
    public JobStatusModel Status { get; set; }
}
