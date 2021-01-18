using System.Threading.Tasks;

namespace Fireblocks.Services
{
    public interface IFireblocksClient
    {
        Task<T> GetAsync<T>(string requestUri) where T : class;
        Task GetAsync(string requestUri);
        Task<TReturn> PostAsync<TReturn, TBody>(string requestUri, TBody requestBody) where TReturn : class 
                                                                                      where TBody : class;
    }
}
