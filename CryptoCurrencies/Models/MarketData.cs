using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CryptoCurrencies.Models
{
    public class MarketData : MarketDataBase
    {
        [JsonPropertyName("roi")]
        public Roi Roi { get; set; }

        [JsonPropertyName("current_price")]
        public Dictionary<string, decimal?> CurrentPrice { get; set; }

        [JsonPropertyName("market_cap")]
        public Dictionary<string, decimal?> MarketCap { get; set; }

        [JsonPropertyName("total_volume")]
        public Dictionary<string, decimal?> TotalVolume { get; set; }

        [JsonPropertyName("high_24h")]
        public Dictionary<string, decimal?> High24H { get; set; }

        [JsonPropertyName("low_24h")]
        public Dictionary<string, decimal?> Low24H { get; set; }

        [JsonPropertyName("price_change_percentage_7d")]
        public string PriceChangePercentage7D { get; set; }

        [JsonPropertyName("price_change_percentage_14d")]
        public string PriceChangePercentage14D { get; set; }

        [JsonPropertyName("price_change_percentage_30d")]
        public string PriceChangePercentage30D { get; set; }

        [JsonPropertyName("price_change_percentage_60d")]
        public string PriceChangePercentage60D { get; set; }

        [JsonPropertyName("price_change_percentage_200d")]
        public string PriceChangePercentage200D { get; set; }

        [JsonPropertyName("price_change_percentage_1y")]
        public string PriceChangePercentage1Y { get; set; }

        [JsonPropertyName("price_change_24h_in_currency")]
        public Dictionary<string, decimal> PriceChange24HInCurrency { get; set; }

        [JsonPropertyName("price_change_percentage_1h_in_currency")]
        public Dictionary<string, double> PriceChangePercentage1HInCurrency { get; set; }

        [JsonPropertyName("price_change_percentage_24h_in_currency")]
        public Dictionary<string, double> PriceChangePercentage24HInCurrency { get; set; }

        [JsonPropertyName("price_change_percentage_7d_in_currency")]
        public Dictionary<string, double> PriceChangePercentage7DInCurrency { get; set; }

        [JsonPropertyName("price_change_percentage_14d_in_currency")]
        public Dictionary<string, double> PriceChangePercentage14DInCurrency { get; set; }

        [JsonPropertyName("price_change_percentage_30d_in_currency")]
        public Dictionary<string, double> PriceChangePercentage30DInCurrency { get; set; }

        [JsonPropertyName("price_change_percentage_60d_in_currency")]
        public Dictionary<string, double> PriceChangePercentage60DInCurrency { get; set; }

        [JsonPropertyName("price_change_percentage_200d_in_currency")]
        public Dictionary<string, double> PriceChangePercentage200DInCurrency { get; set; }

        [JsonPropertyName("price_change_percentage_1y_in_currency")]
        public Dictionary<string, double> PriceChangePercentage1YInCurrency { get; set; }

        [JsonPropertyName("market_cap_change_24h_in_currency")]
        public Dictionary<string, decimal> MarketCapChange24HInCurrency { get; set; }

        [JsonPropertyName("market_cap_change_percentage_24h_in_currency")]
        public Dictionary<string, decimal> MarketCapChangePercentage24HInCurrency { get; set; }
    }

    public class Roi
    {
        [JsonPropertyName("times")]
        public decimal? Times { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("percentage")]
        public decimal? Percentage { get; set; }
    }
}
