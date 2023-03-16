using CryptoCurrencies.Models;
using CryptoCurrencies.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoCurrencies.Api.Clients.Abstractions
{
    public interface ICoinsClient
    {
        Task<List<CoinMarketsViewModel>> GetCoinMarkets(string vsCurrency, string[] ids, string order, int? perPage, int page,
            bool sparkline, string priceChangePercentage, string category);
        Task<CoinList> GetAllCoinDataWithId(string id, string localization, bool tickers,
            bool marketData, bool communityData, bool developerData, bool sparkline);
        Task<MarketChartById> GetMarketChartRangeByCoinId(string id, string vsCurrency, string from, string to);
    }
}
