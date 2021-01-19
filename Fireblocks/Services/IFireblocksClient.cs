using System.Threading.Tasks;

namespace Fireblocks.Services
{
    public interface IFireblocksClient
    {
        Task<TReturn> GetAsync<TReturn>(string requestUri) where TReturn : class;
        Task GetAsync(string requestUri);
        Task<TReturn> PostAsync<TReturn, TBody>(string requestUri, TBody requestBody) where TReturn : class 
                                                                                      where TBody : class;
        Task<TReturn> PostAsync<TReturn>(string requestUri) where TReturn : class;
    }
}
