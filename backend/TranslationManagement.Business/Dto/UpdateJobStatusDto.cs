namespace TranslationManagement.Business.Dto;

public class UpdateJobStatusDto
{
    public int JobId { get; set; }
    public int TranslatorId { get; set; }
    public JobStatusDto Status { get; set; }
}
