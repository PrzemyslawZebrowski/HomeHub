using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.Services;
using HomeHub.Domain.Constants;
using HomeHub.Domain.Enums.Common;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace HomeHub.Infrastructure.Services;

public class CurrencyService : ICurrencyService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMemoryCache _memoryCache;

    public CurrencyService(IHttpClientFactory httpClientFactory, IMemoryCache memoryCache)
    {
        _httpClientFactory = httpClientFactory;
        _memoryCache = memoryCache;
    }

    public async Task<decimal> CalculatePrice(decimal price, CurrencyEnum currencyFrom, CurrencyEnum currencyTo, CancellationToken cancellationToken)
    {
        return await GetExchangeRate(currencyFrom, currencyTo, cancellationToken) * price;
    }

    private async Task<decimal> GetExchangeRate(CurrencyEnum currencyFrom, CurrencyEnum currencyTo,
        CancellationToken cancellationToken)
    {
        var rateFrom = await GetExchangeRateByCurrency(currencyFrom, cancellationToken);
        var rateTo = await GetExchangeRateByCurrency(currencyTo, cancellationToken);

        return rateFrom / rateTo;
    }

    private async Task<decimal> GetExchangeRateByCurrency(CurrencyEnum currency, CancellationToken cancellationToken)
    {
        var cacheRate = _memoryCache.Get(currency.ToString());
        if (cacheRate != null)
        {
            return (decimal)cacheRate;
        }

        var rate = await FetchRate(currency, cancellationToken);

        _memoryCache.Set(currency.ToString(), rate, new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });

        return rate;
    }

    private async Task<decimal> FetchRate(CurrencyEnum currency, CancellationToken cancellationToken)
    {
        if (currency == CurrencyEnum.PLN) return decimal.One;

        var client = _httpClientFactory.CreateClient(HttpClientsNames.NbpApi);
        var response = await client.GetStringAsync(currency.ToString(), cancellationToken);
        var responseObject = JObject.Parse(response);

        return (decimal)responseObject["rates"]?[0]?["mid"];
    }
}