using CryptoCurrencies.Api.Clients.Abstractions;
using System;
using System.Net.Http;

namespace CryptoCurrencies.Api.Clients.Implementations
{
    public partial class CoinGeckoClient : IDisposable, ICoinGeckoClient
    {
        private static readonly Lazy<CoinGeckoClient> Lazy = new(() => new CoinGeckoClient());

        private readonly HttpClient _httpClient;
        private bool _isDisposed;

        public CoinGeckoClient()
        {
            _httpClient = new HttpClient();
        }

        public static CoinGeckoClient Instance => Lazy.Value;

        public ICoinsClient CoinsClient => new CoinsClient(_httpClient);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }
            if (disposing)
            {
                _httpClient?.Dispose();
            }
            _isDisposed = true;
        }
    }
}
