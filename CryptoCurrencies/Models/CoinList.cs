using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CryptoCurrencies.Models
{
    public class CoinList : CoinListWithoutMarketData
    {
        [JsonPropertyName("block_time_in_minutes")]
        public long? BlockTimeInMinutes { get; set; }

        [JsonPropertyName("categories")]
        public string[] Categories { get; set; }

        [JsonPropertyName("description")]
        public Dictionary<string, string> Description { get; set; }

        //[JsonPropertyName("links")]
        //public Links Links { get; set; }

        [JsonPropertyName("country_origin")]
        public string CountryOrigin { get; set; }

        //[JsonPropertyName("genesis_date")]
        //[JsonConverter(typeof(CustomDateTimeConverter))]
        //public DateTime GenesisDate { get; set; }

        [JsonPropertyName("market_cap_rank")]
        public long? MarketCapRank { get; set; }

        [JsonPropertyName("coingecko_rank")]
        public long? CoinGeckoRank { get; set; }

        [JsonPropertyName("coingecko_score")]
        public double? CoinGeckoScore { get; set; }

        [JsonPropertyName("developer_score")]
        public double? DeveloperScore { get; set; }

        [JsonPropertyName("community_score")]
        public double? CommunityScore { get; set; }

        [JsonPropertyName("liquidity_score")]
        public double? LiquidityScore { get; set; }

        [JsonPropertyName("public_interest_score")]
        public double? PublicInterestScore { get; set; }

        [JsonPropertyName("market_data")]
        public CoinByIdMarketData MarketData { get; set; }

        [JsonPropertyName("status_updates")]
        public object[] StatusUpdates { get; set; }

        //[JsonPropertyName("tickers")]
        //public Ticker[] Tickers { get; set; }
    }

}
