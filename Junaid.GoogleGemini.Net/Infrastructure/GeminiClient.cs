namespace Junaid.GoogleGemini.Net.Infrastructure;

public class GeminiClient(HttpClient httpClient) : IGeminiClient
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task GetFooAsync()
    {
        await _httpClient.GetAsync("");
    }
}