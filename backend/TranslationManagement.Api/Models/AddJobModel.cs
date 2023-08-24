namespace TranslationManagement.Api.Models;

public class AddJobModel
{
    public string CustomerName { get; set; } = string.Empty;
    public string OriginalContent { get; set; } = string.Empty;
    public string TranslatedContent { get; set; } = string.Empty;
    public double Price { get; set; }
}
