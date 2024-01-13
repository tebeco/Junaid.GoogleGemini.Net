namespace Junaid.GoogleGemini.Net.Infrastructure;

public class FooHttpClientOptions : IBasicAuthHttpClientOptions
{
    public required Uri Url { get; set; }

    public required BasicAuthCredential Credentials { get; set; }
}