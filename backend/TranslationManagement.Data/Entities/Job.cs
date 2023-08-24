using System.ComponentModel.DataAnnotations;

namespace TranslationManagement.Data.Entities;

public class Job
{
    [Key]
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string Status { get; set; }
    public string OriginalContent { get; set; }
    public string TranslatedContent { get; set; }
    public double Price { get; set; }
}
