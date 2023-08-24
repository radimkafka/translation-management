using System.Xml.Linq;

namespace TranslationManagement.Api;

internal static class JobFileReader
{
    public static (string? customerName, string? content) Read(IFormFile file)
    {
        return file.FileName switch
        {
            var a when a.EndsWith(".txt") => (null, ReadFromTxt(file)),
            var a when a.EndsWith(".xml") => ReadFromXml(file),
            _ => throw new NotSupportedException("unsupported file")
        };
    }

    private static string ReadFromTxt(IFormFile file)
    {
        using var reader = new StreamReader(file.OpenReadStream());
        return reader.ReadToEnd();
    }

    private static (string? customerName, string? content) ReadFromXml(IFormFile file)
    {
        using var reader = new StreamReader(file.OpenReadStream());
        var xdoc = XDocument.Parse(reader.ReadToEnd());
        var content = xdoc?.Root?.Element("Content")?.Value;
        var customer = xdoc?.Root?.Element("Customer")?.Value.Trim();
        return (customer, content);
    }
}
