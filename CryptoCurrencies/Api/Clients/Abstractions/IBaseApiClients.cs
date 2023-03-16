using System;
using System.Threading.Tasks;

namespace CryptoCurrencies.Api.Clients.Abstractions
{
    public interface IBaseApiClients
    {
        Task<T> GetAsync<T>(Uri resourceUri);
    }
}
