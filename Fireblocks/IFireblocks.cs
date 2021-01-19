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
        Task UnhideVaultFromWebConsoleView(string vaultAccountId);
        Task<List<VaultWalletAddress>> GetAddressesOfVaultWallet(string vaultAccountId, string assetId, string eosAccountName = null);
        Task<List<TransactionDetails>> ListTransactions(string before = null, string after = null, string status = null, string orderBy = null, string sourceType = null, string sourceId = null, string destType = null, string destId = null, string assets = null, string txHash = null, string limit = null);
        Task<CreateTransactionResponse> CreateTransaction(string assetId, TransferPeerPath source, DestinationTransferPeerPath destination, string amount, TransactionRequestDestination[] destinations, string fee = null,
                                                          string gasPrice = null, string gasLimit = null, string networkFee = null, string feeLevel = null, string maxFee = null, bool? failOnLowFee = null, string note = null,
                                                          bool? autoStaking = null, string networkStaking = null, string cpuStaking = null, TransactionOperation operation = null, string customerRefId = null,
                                                          string replaceTxByHash = null, string extraParameters = null);
    }
}
