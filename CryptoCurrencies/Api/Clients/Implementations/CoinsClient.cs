using CryptoCurrencies.Api.Clients.Abstractions;
using CryptoCurrencies.Api.EndPoints;
using CryptoCurrencies.Models;
using CryptoCurrencies.Services;
using CryptoCurrencies.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoCurrencies.Api.Clients.Implementations
{
    public class CoinsClient : BaseApiClient, ICoinsClient
    {
        public CoinsClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<List<CoinMarketsViewModel>> GetCoinMarkets(string vsCurrency, string[] ids, string order, int? perPage, int page,
            bool sparkline, string priceChangePercentage, string category)
        {
            return await GetAsync<List<CoinMarketsViewModel>>(QueryStringService.AppendQueryString(CoinsApiEndPoints.CoinMarkets,
                new Dictionary<string, object>
                {
                    { "vs_currency", vsCurrency },
                    { "ids", string.Join(",", ids) },
                    { "order", order },
                    { "per_page", perPage },
                    { "page", page },
                    { "sparkline", sparkline },
                    { "price_change_percentage", priceChangePercentage },
                    { "category", category }
                })).ConfigureAwait(false);
        }

        public async Task<CoinList> GetAllCoinDataWithId(string id, string localization, bool tickers,
            bool marketData, bool communityData, bool developerData, bool sparkline)
        {
            return await GetAsync<CoinList>(QueryStringService.AppendQueryString(
                CoinsApiEndPoints.AllDataByCoinId(id), new Dictionary<string, object>
                {
                    {"localization", localization},
                    {"tickers", tickers},
                    {"market_data", marketData},
                    {"community_data", communityData},
                    {"developer_data", developerData},
                    {"sparkline", sparkline}
                })).ConfigureAwait(false);
        }

        public async Task<MarketChartById> GetMarketChartRangeByCoinId(string id, string vsCurrency, string @from, string to)
        {
            return await GetAsync<MarketChartById>(QueryStringService.AppendQueryString(
                CoinsApiEndPoints.MarketChartRangeByCoinId(id), new Dictionary<string, object>
                {
                    {"vs_currency", string.Join(",", vsCurrency)},
                    {"from",from},
                    {"to",to}
                })).ConfigureAwait(false);
        }
    }
}
