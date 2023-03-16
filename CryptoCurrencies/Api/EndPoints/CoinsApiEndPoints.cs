namespace CryptoCurrencies.Api.EndPoints
{
    public static class CoinsApiEndPoints
    {
        public static readonly string CoinMarkets = "coins/markets";
        public static string AllDataByCoinId(string id) => BaseApiEndPointUrl.AddCoinsIdUrl(id);
        public static string MarketChartRangeByCoinId(string id) => BaseApiEndPointUrl.AddCoinsIdUrl(id) + "/market_chart/range";
    }
}
