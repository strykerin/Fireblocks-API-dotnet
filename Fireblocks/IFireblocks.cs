using System.Collections.Generic;
using System.Threading.Tasks;
using Fireblocks.Entities;

namespace Fireblocks
{
    public interface IFireblocks
    {
        /// <summary>
        /// Returns all accounts of the active Vault
        /// </summary>
        /// <returns>
        /// Returns an array of VaultAccount objects.
        /// </returns>
        Task<List<VaultAccount>> GetVaults();

        /// <summary>
        /// Returns the requested Vault Account.
        /// </summary>
        /// <param name="vaultAccountId"></param>
        /// <returns></returns>
        Task<VaultAccount> GetVault(string vaultAccountId);

        /// <summary>
        /// Creates a new Vault Account with the requested name.
        /// </summary>
        /// <param name="name">The name of the new account (this can be renamed later)</param>
        /// <param name="hiddenOnUI">[optional] Should be set to true if you wish this account will not appear in the web console, false by default</param>
        /// <param name="customerRefId">[optional] The ID for AML providers to associate the owner of funds with transactions</param>
        /// <param name="autoFuel">[optional] In case the Gas Station service is enabled on your workspace, this flag needs to be set to "true" if you wish to add this account's Ethereum address to be monitored and fueled upon detected deposits of ERC20 tokens.</param>
        /// <returns></returns>
        Task<VaultAccount> CreateVault(string name, bool? hiddenOnUI = null, string customerRefId = null, bool? autoFuel = null);

        /// <summary>
        /// Retrieves a wallet of a specific asset under a Fireblocks Vault Account.
        /// </summary>
        /// <param name="vaultAccountId">The ID of the vault account to return, or 'default' for the default vault account</param>
        /// <param name="assetId">The ID of the asset</param>
        /// <returns></returns>
        Task<VaultAsset> GetVaultWallet(string vaultAccountId, string assetId);
        
        /// <summary>
        /// Creates a new wallet of a specific asset under a Fireblocks Vault Account.
        /// </summary>
        /// <param name="vaultAccountId">The ID of the vault account, or 'default' for the default vault account</param>
        /// <param name="assetId">The ID of the asset</param>
        /// <param name="EosAccountName">[optional] EOS account address</param>
        /// <returns></returns>
        Task<CreateVaultAssetResponse> CreateNewWalletForVault(string vaultAccountId, string assetId, string EosAccountName = null);

        /// <summary>
        /// Hides the Vault Account from the web console view.
        /// </summary>
        /// <param name="vaultAccountId">The ID of the vault account to hide from the web console</param>
        /// <returns></returns>
        Task HideVaultFromWebConsoleView(string vaultAccountId);

        /// <summary>
        /// Returns the Vault Account to be visible in the web console.
        /// </summary>
        /// <param name="vaultAccountId">The ID of the vault account to be visible in the web console</param>
        /// <returns></returns>
        Task UnhideVaultFromWebConsoleView(string vaultAccountId);

        /// <summary>
        /// Retrieves all addresses of a specific asset inside a Fireblocks Vault Account.
        /// </summary>
        /// <param name="vaultAccountId">The ID of the vault account to return, or 'default' for the default vault account</param>
        /// <param name="assetId">The ID of the asset</param>
        /// <param name="EosAccountName">[optional] EOS account address</param>
        /// <returns></returns>
        Task<List<VaultWalletAddress>> GetAddressesOfVaultWallet(string vaultAccountId, string assetId, string eosAccountName = null);

        /// <summary>
        /// Lists the transaction history for your workspace.
        /// </summary>
        /// <param name="before">[optional] Unix timestamp in milliseconds. Returns only transactions created before the specified date</param>
        /// <param name="after">[optional] Unix timestamp in milliseconds. Returns only transactions created after the specified date</param>
        /// <param name="status">[optional] Comma-separated list of statuses. Returns only transactions with each of the specified statuses</param>
        /// <param name="orderBy">[optional] The field to order the results by. Available values : createdAt (default), lastUpdated</param>
        /// <param name="sourceType">[optional] The source type of the transaction. Available values: VAULT_ACCOUNT, EXCHANGE_ACCOUNT, INTERNAL_WALLET, EXTERNAL_WALLET, FIAT_ACCOUNT, NETWORK_CONNECTION, COMPOUND</param>
        /// <param name="sourceId">[optional] The source ID of the transaction</param>
        /// <param name="destType">[optional] The destination type of the transaction. Available values: VAULT_ACCOUNT, EXCHANGE_ACCOUNT, INTERNAL_WALLET, EXTERNAL_WALLET, FIAT_ACCOUNT, NETWORK_CONNECTION, COMPOUND</param>
        /// <param name="destId">[optional] The destination ID of the transaction</param>
        /// <param name="assets">[optional] A list of assets to filter by, seperated by commas</param>
        /// <param name="txHash">[optional] Returns only results with a specified txHash</param>
        /// <param name="limit">[optional] Limits the number of returned transactions. If not provided, a defult of 200 will be returned. The maximum allowed limit is 500.</param>
        /// <returns></returns>
        Task<List<TransactionDetails>> GetTransactions(string before = null, string after = null, string status = null, string orderBy = null, string sourceType = null, string sourceId = null, string destType = null, string destId = null, string assets = null, string txHash = null, string limit = null);

        /// <summary>
        /// Submits a new transaction on the Fireblocks platform.
        /// </summary>
        /// <param name="assetId">The ID of the asset</param>
        /// <param name="source">The source account of the transaction</param>
        /// <param name="destination">The destination of the transaction</param>
        /// <param name="amount">The requested amount to transfer</param>
        /// <param name="destinations">For UTXO based assets, you can send a single transaction to multiple destinations which should be specified using this field</param>
        /// <param name="fee"></param>
        /// <param name="gasPrice"></param>
        /// <param name="gasLimit"></param>
        /// <param name="networkFee"></param>
        /// <param name="feeLevel"></param>
        /// <param name="maxFee"></param>
        /// <param name="failOnLowFee"></param>
        /// <param name="note"></param>
        /// <param name="autoStaking"></param>
        /// <param name="networkStaking"></param>
        /// <param name="cpuStaking"></param>
        /// <param name="operation"></param>
        /// <param name="customerRefId"></param>
        /// <param name="replaceTxByHash"></param>
        /// <param name="extraParameters"></param>
        /// <returns></returns>
        Task<CreateTransactionResponse> CreateTransaction(string assetId, TransferPeerPath source, DestinationTransferPeerPath destination, string amount, TransactionRequestDestination[] destinations, string fee = null,
                                                          string gasPrice = null, string gasLimit = null, string networkFee = null, string feeLevel = null, string maxFee = null, bool? failOnLowFee = null, string note = null,
                                                          bool? autoStaking = null, string networkStaking = null, string cpuStaking = null, TransactionOperation operation = null, string customerRefId = null,
                                                          string replaceTxByHash = null, string extraParameters = null);

        /// <summary>
        /// Retrieves a specific transaction for the requested transaction ID.
        /// </summary>
        /// <param name="txId">The ID of the transaction to return</param>
        /// <returns></returns>
        Task<TransactionDetails> GetTransactionById(string txId);

        /// <summary>
        /// Cancel the requested transaction.
        /// </summary>
        /// <param name="txId">The ID of the transaction to return</param>
        /// <returns>Returns the status of the request.</returns>
        Task<RequestStatus> CancelTransaction(string txId);

        /// <summary>
        /// Replaces Ethereum transactions that are stuck with 0 confirmation. This request creates a new transaction that can replace the stalled transaction, with the same source as the original one, with 0 ETH sent to itself. By using the same nonce as the original one, it will drop the original transaction once the new transaction will be mined.
        /// A stuck transaction can be replaced by a different transaction using the create transaction endpoint and the "replaceTxByHash" field.
        /// </summary>
        /// <param name="txId">The ID of the transaction to return</param>
        /// <param name="feeLevel">[optional] The requested fee level of the dropping transaction (LOW / MEDIUM / HIGH)</param>
        /// <returns>Returns the transaction id of the replacing transaction.</returns>
        Task<RequestStatus> DropTransaction(string txId, string feeLevel = null);

        /// <summary>
        /// Retrieves the current blockchain fees based on the requested asset.
        /// </summary>
        /// <param name="assetId">The asset for which you wish to retrieve the network fees</param>
        /// <returns>Returns NetworkFee objects for low, medium and high fees.</returns>
        Task<NetworkFeeResponse> GetNetworkFee(string assetId);

        /// <summary>
        /// Estimates the transaction fee for a given transaction request.
        /// </summary>
        /// <param name="assetId">The ID of the asset</param>
        /// <param name="amount">The requested amount to transfer</param>
        /// <param name="source">The source of the estimated transaction</param>
        /// <param name="destination">The destination of the estimated transaction. For some blockchains it can affect the transaction fee.</param>
        /// <param name="operation">[optional] Transaction operation type, the default is "TRANSFER"</param>
        /// <returns>Returns an EstimatedTransactionFeeResponse object.</returns>
        Task<EstimatedTransactionFeeResponse> EstimateTransactionFee(string assetId, string amount, TransferPeerPath source, DestinationTransferPeerPath destination = null, TransactionOperation operation = null);
    }
}
