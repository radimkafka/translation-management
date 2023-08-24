namespace TranslationManagement.Business.Dto;

public class AddJobDto
{
    public string CustomerName { get; set; } = string.Empty;
    public string OriginalContent { get; set; } = string.Empty; 
    public string TranslatedContent { get; set; } = string.Empty;
    public double Price { get; set; }
}
