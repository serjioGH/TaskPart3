using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Cloth.Infrastructure;

using Cloth.Infrastructure.Extensions;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cloth.Application.Interfaces;

public class ReadJsonFromUrlClient : IReadJsonFromUrlClient
{
    private readonly ILogger<ReadJsonFromUrlClient> _logger;
    private readonly HttpClient _httpClient;

    public ReadJsonFromUrlClient(ILogger<ReadJsonFromUrlClient> logger, HttpClient httpClient)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    /// <summary>
    /// Creates a request to get the data and deserializes the response to create a list of items
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Cloth>> GetClothsAsync(string url)
    {
        try
        {
            ReadFromUrlLoggerExtensions.LogHttpClientGet(_logger);
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var cloths = JsonSerializer.Deserialize<IEnumerable<Cloth>>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                ReadFromUrlLoggerExtensions.LogGetItemsResponse(_logger, content);
                return cloths;
            }
            else
            {
                ReadFromUrlLoggerExtensions.LogFailedGetItems(_logger);
                throw new HttpRequestException($"Failed to get items with status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            ReadFromUrlLoggerExtensions.LogHttpClientGetFailed(_logger);
            throw new Exception("An error occurred while getting items from Url.", ex);
        }
    }

}

