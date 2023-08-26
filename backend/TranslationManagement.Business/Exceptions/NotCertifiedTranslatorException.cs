namespace TranslationManagement.Business.Exceptions;

public class NotCertifiedTranslatorException : Exception
{
    public NotCertifiedTranslatorException() : base("Only certified translator can work on a job.")
    {

    }
}
