namespace CryptoCurrencies.Api.Clients.Abstractions
{
    public interface ICoinGeckoClient
    {
        ICoinsClient CoinsClient { get; }
    }
}
