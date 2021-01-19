using Fireblocks.Exceptions;
using System.Threading.Tasks;
using System;
using Fireblocks.Entities;
using Fireblocks.Services;
using System.Collections.Generic;
using System.Web;
using System.Collections.Specialized;

namespace Fireblocks
{
    public class Fireblocks : IFireblocks
    {
        private const string _messageErrorHttpClient = "There was an error in HttpClient";
        private const string _messageErrorInvalidInputParameters = "Invalid input parameters";

        private readonly IFireblocksClient _fireblocksClient;

        public Fireblocks(IFireblocksClient fireblocksClient)
        {
            _fireblocksClient = fireblocksClient;
        }

        public async Task<List<VaultAccount>> GetVaults()
        {
            try
            {
                string requestUri = "/v1/vault/accounts";

                List<VaultAccount> vaultAccounts = await _fireblocksClient.GetAsync<List<VaultAccount>>(requestUri);
                return vaultAccounts;
            }
            catch (Exception ex)
            {
                throw new FireblocksException(_messageErrorHttpClient, ex);
            }
        }

        public async Task<VaultAccount> GetVault(string vaultAccountId)
        {
            if (string.IsNullOrEmpty(vaultAccountId))
            {
                throw new ArgumentException(_messageErrorInvalidInputParameters);
            }
            try
            {
                string requestUri = $"/v1/vault/accounts/{vaultAccountId}";

                VaultAccount vaultAccount = await _fireblocksClient.GetAsync<VaultAccount>(requestUri);
                return vaultAccount;
            }
            catch (Exception ex)
            {
                throw new FireblocksException(_messageErrorHttpClient, ex);
            }
        }

        public async Task<VaultAccount> CreateVault(string name, bool? hiddenOnUI = null, string customerRefId = null, bool? autoFuel = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new FireblocksException(_messageErrorInvalidInputParameters);
            }
            try
            {
                string requestUri = "/v1/vault/accounts";

                CreateVaultAccount createVaultAccount = new CreateVaultAccount(name: name)
                {
                    HiddenOnUI = hiddenOnUI,
                    CustomerRefId = customerRefId,
                    AutoFuel = autoFuel
                };
                VaultAccount vaultAccount = await _fireblocksClient.PostAsync<VaultAccount, CreateVaultAccount>(requestUri, createVaultAccount);
                return vaultAccount;
            }
            catch (Exception ex)
            {
                throw new FireblocksException(_messageErrorHttpClient, ex);
            }
        }

        public async Task<VaultAsset> GetVaultWallet(string vaultAccountId, string assetId)
        {
            if (string.IsNullOrEmpty(vaultAccountId) || string.IsNullOrEmpty(assetId))
            {
                throw new FireblocksException(_messageErrorInvalidInputParameters);
            }
            try
            {
                string requestUri = $"/v1/vault/accounts/{vaultAccountId}/{assetId}";

                VaultAsset vaultAsset = await _fireblocksClient.GetAsync<VaultAsset>(requestUri);
                return vaultAsset;
            }
            catch (Exception ex)
            {
                throw new FireblocksException(_messageErrorHttpClient, ex);
            }
        }

        public async Task<CreateVaultAssetResponse> CreateNewWalletForVault(string vaultAccountId, string assetId, string EosAccountName = null)
        {
            if (string.IsNullOrEmpty(vaultAccountId) || string.IsNullOrEmpty(assetId))
            {
                throw new FireblocksException(_messageErrorInvalidInputParameters);
            }
            try
            {
                string requestUri = $"/v1/vault/accounts/{vaultAccountId}/{assetId}";

                CreateWalletForVault createNewWalletForVault = new CreateWalletForVault
                {
                    EosAccountName = EosAccountName
                };

                CreateVaultAssetResponse response = await _fireblocksClient.PostAsync<CreateVaultAssetResponse, CreateWalletForVault>(requestUri, createNewWalletForVault);
                return response;
            }
            catch (Exception ex)
            {
                throw new FireblocksException(_messageErrorHttpClient, ex);
            }
        }

        public async Task HideVaultFromWebConsoleView(string vaultAccountId)
        {
            if (string.IsNullOrEmpty(vaultAccountId))
            {
                throw new FireblocksException(_messageErrorInvalidInputParameters);
            }
            try
            {
                string requestUri = $"/v1/vault/accounts/{vaultAccountId}/hide";
                await _fireblocksClient.GetAsync(requestUri);
            }
            catch (Exception ex)
            {
                throw new FireblocksException(_messageErrorHttpClient, ex);
            }
        }

        public async Task UnhideVaultFromWebConsoleView(string vaultAccountId)
        {
            if (string.IsNullOrEmpty(vaultAccountId))
            {
                throw new FireblocksException(_messageErrorInvalidInputParameters);
            }
            try
            {
                string requestUri = $"/v1/vault/accounts/{vaultAccountId}/unhide";
                await _fireblocksClient.GetAsync(requestUri);
            }
            catch (Exception ex)
            {
                throw new FireblocksException(_messageErrorHttpClient, ex);
            }
        }

        public async Task<List<VaultWalletAddress>> GetAddressesOfVaultWallet(string vaultAccountId, string assetId, string eosAccountName = null)
        {
            if (string.IsNullOrEmpty(vaultAccountId) || string.IsNullOrEmpty(assetId))
            {
                throw new FireblocksException(_messageErrorInvalidInputParameters);
            }
            try
            {
                string requestUri = $"/v1/vault/accounts/{vaultAccountId}/{assetId}/addresses";
                CreateWalletForVault requestBody = new CreateWalletForVault
                {
                    EosAccountName = eosAccountName
                };
                List<VaultWalletAddress> vaultWalletAddress = await _fireblocksClient.PostAsync<List<VaultWalletAddress>, CreateWalletForVault>(requestUri, requestBody);
                return vaultWalletAddress;
            }
            catch (Exception ex)
            {
                throw new FireblocksException(_messageErrorHttpClient, ex);
            }
        }

        public async Task<List<TransactionDetails>> GetTransactions(string before = null, string after = null, string status = null, string orderBy = null, string sourceType = null, string sourceId = null, string destType = null, string destId = null, string assets = null, string txHash = null, string limit = null)
        {
            try
            {
               string requestUri = $"/v1/transactions";
                NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
                if (!(before is null))
                    query[$"{nameof(before)}"] = before;
                if (!(after is null))
                    query[$"{nameof(after)}"] = after;
                if (!(status is null))
                    query[$"{nameof(status)}"] = status;
                if (!(orderBy is null))
                    query[$"{nameof(orderBy)}"] = orderBy;
                if (!(sourceType is null))
                    query[$"{nameof(sourceType)}"] = sourceType;
                if (!(sourceId is null))
                    query[$"{nameof(sourceId)}"] = sourceId;
                if (!(destType is null))
                    query[$"{nameof(destType)}"] = destType;
                if (!(destId is null))
                    query[$"{nameof(destId)}"] = destId;
                if (!(assets is null))
                    query[$"{nameof(assets)}"] = assets;
                if (!(txHash is null))
                    query[$"{nameof(txHash)}"] = txHash;
                if (!(limit is null))
                    query[$"{nameof(limit)}"] = limit;

                string queryString = query.ToString();
                requestUri += queryString;

                List<TransactionDetails> transactionsDetails = await _fireblocksClient.GetAsync<List<TransactionDetails>>(requestUri);
                return transactionsDetails;
            }
            catch (Exception ex)
            {
                throw new FireblocksException(_messageErrorHttpClient, ex);
            }
        }

        public async Task<CreateTransactionResponse> CreateTransaction(string assetId, TransferPeerPath source, DestinationTransferPeerPath destination, string amount, TransactionRequestDestination[] destinations, string fee = null, 
                                            string gasPrice = null, string gasLimit = null, string networkFee = null, string feeLevel = null, string maxFee = null, bool? failOnLowFee = null, string note = null, 
                                            bool? autoStaking = null, string networkStaking = null, string cpuStaking = null, TransactionOperation operation = null, string customerRefId = null, 
                                            string replaceTxByHash = null, string extraParameters = null)
        {
            if (string.IsNullOrEmpty(assetId) || source is null || destination is null || string.IsNullOrEmpty(amount) || destinations is null)
            {
                throw new FireblocksException(_messageErrorInvalidInputParameters);
            }
            try
            {
                string requestUri = $"/v1/transactions";
                CreateTransaction createTransaction = new CreateTransaction(assetId: assetId, source: source, destination: destination, amount: amount, destinations: destinations)
                {
                    Fee = fee,
                    GasPrice = gasPrice,
                    GasLimit = gasLimit,
                    NetworkFee = networkFee,
                    FeeLevel = feeLevel,
                    MaxFee = maxFee,
                    FailOnLowFee = failOnLowFee,
                    Note = note,
                    AutoStaking = autoStaking,
                    NetworkStaking = networkStaking,
                    CpuStaking = cpuStaking,
                    Operation = operation,
                    CustomerRefId = customerRefId,
                    ReplaceTxByHash = replaceTxByHash,
                    ExtraParameters = extraParameters
                };

                CreateTransactionResponse createTransactionResponse =  await _fireblocksClient.PostAsync<CreateTransactionResponse, CreateTransaction>(requestUri, createTransaction);
                return createTransactionResponse;
            }
            catch (Exception ex)
            {
                throw new FireblocksException(_messageErrorHttpClient, ex);
            }
        }

        public async Task<TransactionDetails> GetTransactionById(string txId)
        {
            if (string.IsNullOrEmpty(txId))
            {
                throw new FireblocksException(_messageErrorInvalidInputParameters);
            }
            try
            {
                string requestUri = $"/v1/transactions/{txId}";
                TransactionDetails transactionDetails = await _fireblocksClient.GetAsync<TransactionDetails>(requestUri);
                return transactionDetails;
            }
            catch (Exception ex)
            {
                throw new FireblocksException(_messageErrorHttpClient, ex);
            }
        }

        public async Task<RequestStatus> CancelTransaction(string txId)
        {
            if (string.IsNullOrEmpty(txId))
            {
                throw new FireblocksException(_messageErrorInvalidInputParameters);
            }
            try
            {
                string requestUri = $"/v1/transactions/{txId}";
                RequestStatus requestStatus = await _fireblocksClient.PostAsync<RequestStatus>(requestUri);
                return requestStatus;
            }
            catch (Exception ex)
            {
                throw new FireblocksException(_messageErrorHttpClient, ex);
            }
        }

        public async Task<RequestStatus> DropTransaction(string txId, string feeLevel = null)
        {
            if (string.IsNullOrEmpty(txId))
            {
                throw new FireblocksException(_messageErrorInvalidInputParameters);
            }
            try
            {
                DropTransaction dropTransaction = new DropTransaction
                {
                    FeeLevel = feeLevel
                };

                string requestUri = $"/v1/transactions/{txId}";
                RequestStatus requestStatus = await _fireblocksClient.PostAsync<RequestStatus, DropTransaction>(requestUri, dropTransaction);
                return requestStatus;
            }
            catch (Exception ex)
            {
                throw new FireblocksException(_messageErrorHttpClient, ex);
            }
        }

        public async Task<NetworkFeeResponse> GetNetworkFee(string assetId)
        {
            if (string.IsNullOrEmpty(assetId))
            {
                throw new FireblocksException(_messageErrorInvalidInputParameters);
            }
            try
            {
                string requestUri = $"/v1/estimate_network_fee?assetId={assetId}";
                NetworkFeeResponse networkFeeResponse = await _fireblocksClient.GetAsync<NetworkFeeResponse>(requestUri);
                return networkFeeResponse;
            }
            catch (Exception ex)
            {
                throw new FireblocksException(_messageErrorHttpClient, ex);
            }
        }

        public async Task<EstimatedTransactionFeeResponse> EstimateTransactionFee(string assetId, string amount, TransferPeerPath source, DestinationTransferPeerPath destination = null, TransactionOperation operation = null)
        {
            if (string.IsNullOrEmpty(assetId) || string.IsNullOrEmpty(amount) || source is null)
            {
                throw new FireblocksException(_messageErrorInvalidInputParameters);
            }
            try
            {
                string requestUri = $"/v1/transactions/estimate_fee";
                EstimatedTransactionFee estimatedTransactionFee = new EstimatedTransactionFee(assetId: assetId, amount: amount, source: source, destination: destination)
                {
                    Operation = operation
                };

                EstimatedTransactionFeeResponse estimatedTransactionFeeResponse = await _fireblocksClient.PostAsync<EstimatedTransactionFeeResponse, EstimatedTransactionFee>(requestUri, estimatedTransactionFee);
                return estimatedTransactionFeeResponse;
            }
            catch (Exception ex)
            {
                throw new FireblocksException(_messageErrorHttpClient, ex);
            }
        }

        public async Task<GasStationInfo> GasStationSettings()
        {
            try
            {
                string requestUri = $"/v1/gas_station";

                GasStationInfo gasStationInfo = await _fireblocksClient.GetAsync<GasStationInfo>(requestUri);
                return gasStationInfo;
            }
            catch (Exception ex)
            {
                throw new FireblocksException(_messageErrorHttpClient, ex);
            }
        }
    }
}
