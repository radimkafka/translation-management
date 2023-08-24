﻿namespace TranslationManagement.Api.Models;

public class TranslatorModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string HourlyRate { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string CreditCardNumber { get; set; } = string.Empty;
}