using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Controls;

namespace CryptoCurrencies.Models
{
    public class CoinListWithoutMarketData : CoinListBase
    {
        [JsonPropertyName("image")]
        public Image Image { get; set; }

        //[JsonPropertyName("community_data")]
        //public CommunityData CommunityData { get; set; }

        //[JsonPropertyName("developer_data")]
        //public DeveloperData DeveloperData { get; set; }

        //[JsonPropertyName("public_interest_stats")]
        //public PublicInterestStats PublicInterestStats { get; set; }

        [JsonPropertyName("last_updated")]
        public DateTimeOffset? LastUpdated { get; set; }

        [JsonPropertyName("localization")]
        public Dictionary<string, string> Localization { get; set; }
    }
}
