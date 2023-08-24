namespace TranslationManagement.Api.Models
{
    public class AddTranslatorModel
    {
        public string Name { get; set; } = string.Empty;
        
        public uint HourlyRate { get; set; }
        public TranslatorStatusModel Status { get; set; }
        public string CreditCardNumber { get; set; } = string.Empty;
    }
}
