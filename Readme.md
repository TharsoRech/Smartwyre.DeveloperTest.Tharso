using System.Net.Http.Headers;
using System.Text;

using Tke.Gta.Maui.ApiClients.Common;

namespace Tke.Gta.Maui.ApiClients.Retrofit;

public abstract class ApiClientBase(IRetrofitApiBaseUrlConfiguration configuration) : IApiClient
{
    private string _bearerToken;
    private int _statusCode;

    public void UseBearerToken(string token)
    {
        _bearerToken = token;
    }

    protected Task<HttpRequestMessage> CreateHttpRequestMessageAsync(CancellationToken cancellationToken)
    {
        HttpRequestMessage request = new();

        if (_bearerToken != null)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _bearerToken);
        }

        return Task.FromResult(request);
    }

    protected Task ProcessResponseAsync(HttpClient client, HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        _statusCode = (int)response.StatusCode;
        return Task.CompletedTask;
    }

    protected Task PrepareRequestAsync(HttpClient client, HttpRequestMessage request,
        StringBuilder url, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    protected Task PrepareRequestAsync(
        HttpClient client,
        HttpRequestMessage request,
        string url,
        CancellationToken cancellationToken)
    {
        if (client.BaseAddress == null
            || !string.Equals(client.BaseAddress.AbsoluteUri, configuration.BaseUrl, StringComparison.OrdinalIgnoreCase))
        {
            client.BaseAddress = new Uri(configuration.BaseUrl);
        }

        return Task.CompletedTask;
    }

    public int GetStatusCode()
    {
        return _statusCode;
    }
}
