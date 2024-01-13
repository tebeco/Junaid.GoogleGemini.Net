namespace Junaid.GoogleGemini.Net.Infrastructure;

public interface IBasicAuthHttpClientOptions
{
    Uri Url { get; set; }
    
    BasicAuthCredential Credentials { get; set; }
}