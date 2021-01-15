using System.Collections.Generic;
using System.Threading.Tasks;
using Fireblocks.Entities;

namespace Fireblocks
{
    public interface IFireblocks
    {
        Task<List<VaultAccount>> GetVaults();
        Task<VaultAccount> GetVault(string vaultAccountId);
        Task<VaultAccount> CreateVault(string name, bool? hiddenOnUI = null, string customerRefId = null, bool? autoFuel = null);
        Task<VaultAsset> GetVaultWallet(string vaultAccountId, string assetId);
        Task<CreateVaultAssetResponse> CreateNewWalletForVault(string vaultAccountId, string assetId, string EosAccountName = null);
        Task HideVaultFromWebConsoleView(string vaultAccountId);
    }
}
