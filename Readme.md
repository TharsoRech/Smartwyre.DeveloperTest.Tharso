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


@kibblewhite.mergelabs.io I was doing some researchs on  your issue about Blank screen and I saw a lot of comments that this is a know issue on Iphone 16 and happened with several users, and some people commented that happen sometimes and normally a restart fix.

 I would you like to do some tests here just to sure that is not anything in your phone:

Restart Your iPhone: try a force restart by quickly pressing and releasing the volume up button, then the volume down button, and finally pressing and holding the side button until the Apple logo appears. 

Reset Camera Settings: Go to Settings > Camera > Reset Settings to reset all camera settings to their defaults. 

and also do you have another app that uses camera?
if there is working fine there?
