using System.Threading.Tasks;

namespace Fireblocks.Services
{
    public interface IFireblocksClient
    {
        Task<T> GetAsync<T>(string requestUri) where T : class;
        Task GetAsync(string requestUri);
        Task<T> PostAsync<T, TBody>(string requestUri, TBody requestBody) where T : class 
                                                                          where TBody : class;
    }
}
