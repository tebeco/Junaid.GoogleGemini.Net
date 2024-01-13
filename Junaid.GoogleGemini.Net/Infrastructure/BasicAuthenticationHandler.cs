using System.Net.Http.Headers;
using Microsoft.Extensions.Options;

namespace Junaid.GoogleGemini.Net.Infrastructure;

public class BasicAuthenticationHandler<TOptions>(IOptions<TOptions> options) : DelegatingHandler
    where TOptions : class, IBasicAuthHttpClientOptions
{
    private readonly TOptions _options = options.Value;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Authorization = new AuthenticationHeaderValue(BasicAuthCredential.Scheme, _options.Credentials.ApiKey);

        return await base.SendAsync(request, cancellationToken);
    }
}