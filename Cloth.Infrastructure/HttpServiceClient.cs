using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Cloth.Infrastructure;

using Cloth.Infrastructure.Extensions;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cloth.Application.Interfaces;
using Cloth.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

public class HttpServiceClient : IHttpServiceClient
{
    private readonly ILogger<HttpServiceClient> _logger;
    private readonly HttpClient _httpClient;
    private readonly MockyHttpConfiguration _jsonPathConfig;

    public HttpServiceClient(ILogger<HttpServiceClient> logger, HttpClient httpClient, IOptions<MockyHttpConfiguration> options)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _jsonPathConfig = options.Value ?? throw new ArgumentNullException(nameof(options));
    }

    /// <summary>
    /// Creates a request to get the data and deserializes the response to create a list of items
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Cloth>> GetClothsAsync()
    {
        try
        {
            MockyHttpClientLoggerExtension.LogHttpClientGet(_logger);
            var response = await _httpClient.GetAsync($"{_jsonPathConfig.Url}{_jsonPathConfig.ProductUrl}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var cloths = JsonSerializer.Deserialize<IEnumerable<Cloth>>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                MockyHttpClientLoggerExtension.LogGetItemsResponse(_logger, content);
                return cloths;
            }
            else
            {
                MockyHttpClientLoggerExtension.LogFailedGetItems(_logger);
                throw new HttpRequestException($"Failed to get items with status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            MockyHttpClientLoggerExtension.LogHttpClientGetFailed(_logger);
            throw new Exception("An error occurred while getting items from Url.", ex);
        }
    }

}

