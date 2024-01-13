using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Junaid.GoogleGemini.Net.Infrastructure;

public static class GeminiExtensions
{
    public const string InvalidApiKeyMessage = "Your API key is invalid, as it is an empty string. You can double-check your API key from the Google Cloud API Credentials page (https://console.cloud.google.com/apis/credentials).";

    public static IServiceCollection AddGemini<THttpClient, THttpClientOptions>(this IServiceCollection services, Action<THttpClientOptions> configure)
        where THttpClient : class 
        where THttpClientOptions : class, IBasicAuthHttpClientOptions
    {
        services
            .AddOptions<THttpClientOptions>()
            .Configure(configure)
            .Validate(options => !string.IsNullOrWhiteSpace(options.Credentials.ApiKey), InvalidApiKeyMessage)
            .ValidateOnStart();

        services.AddTransient<BasicAuthenticationHandler<THttpClientOptions>>();

        services.AddHttpClient<THttpClient>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<THttpClientOptions>>().Value;
            client.BaseAddress = options.Url;
        })
        .AddHttpMessageHandler<BasicAuthenticationHandler<THttpClientOptions>>();

        return services;
    }
}