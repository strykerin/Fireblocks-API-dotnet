using System.Threading.Tasks;
using Fireblocks.Entities;

namespace Fireblocks
{
    public interface IFireblocks
    {
        Task<VaultAccount> GetVault();
    }
}
