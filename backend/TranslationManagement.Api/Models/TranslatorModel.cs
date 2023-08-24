namespace TranslationManagement.Api.Models;

public class TranslatorModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public uint HourlyRate { get; set; }
    public TranslatorStatusModel Status { get; set; }
    public string CreditCardNumber { get; set; } = string.Empty;
}
