using System.ComponentModel.DataAnnotations;

namespace TranslationManagement.Data.Entities;

public class Translator
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string HourlyRate { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string CreditCardNumber { get; set; } = string.Empty;
}
