namespace TranslationManagement.Business.Dto;

public class TranslatorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public uint HourlyRate { get; set; }
    public TranslatorStatusDto Status { get; set; } 
    public string CreditCardNumber { get; set; } = string.Empty;
}
