namespace Junaid.GoogleGemini.Net.Infrastructure;

public class BasicAuthCredential
{
    public const string Scheme = "x-goog-api-key";
    
    public required string ApiKey { get; init; }
}