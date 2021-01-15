using System.Threading.Tasks;

namespace Fireblocks.Services
{
    public interface IFireblocksClient
    {
        Task<T> GetAsync<T>(string requestUri);
        Task<T> PostAsync<T, TBody>(string requestUri, TBody requestBody);
    }
}
