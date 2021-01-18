using Fireblocks.Exceptions;
using System.Threading.Tasks;
using System;
using Fireblocks.Entities;
using Fireblocks.Services;
using System.Collections.Generic;

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

        /// <summary>
        /// Returns all accounts of the active Vault
        /// </summary>
        /// <returns>
        /// Returns an array of VaultAccount objects.
        /// </returns>
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

        /// <summary>
        /// Returns the requested Vault Account.
        /// </summary>
        /// <param name="vaultAccountId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a new Vault Account with the requested name.
        /// </summary>
        /// <param name="name">The name of the new account (this can be renamed later)</param>
        /// <param name="hiddenOnUI">[optional] Should be set to true if you wish this account will not appear in the web console, false by default</param>
        /// <param name="customerRefId">[optional] The ID for AML providers to associate the owner of funds with transactions</param>
        /// <param name="autoFuel">[optional] In case the Gas Station service is enabled on your workspace, this flag needs to be set to "true" if you wish to add this account's Ethereum address to be monitored and fueled upon detected deposits of ERC20 tokens.</param>
        /// <returns></returns>
        public async Task<VaultAccount> CreateVault(string name, bool? hiddenOnUI = null, string customerRefId = null, bool? autoFuel = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new FireblocksException(_messageErrorInvalidInputParameters);
            }
            try
            {
                string requestUri = "/v1/vault/accounts";

                CreateVaultAccount createVaultAccount = new CreateVaultAccount
                {
                    Name = name,
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

        /// <summary>
        /// Retrieves a wallet of a specific asset under a Fireblocks Vault Account.
        /// </summary>
        /// <param name="vaultAccountId">The ID of the vault account to return, or 'default' for the default vault account</param>
        /// <param name="assetId">The ID of the asset</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a new wallet of a specific asset under a Fireblocks Vault Account.
        /// </summary>
        /// <param name="vaultAccountId">The ID of the vault account, or 'default' for the default vault account</param>
        /// <param name="assetId">The ID of the asset</param>
        /// <param name="EosAccountName">[optional] EOS account address</param>
        /// <returns></returns>
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

        /// <summary>
        /// Hides the Vault Account from the web console view.
        /// </summary>
        /// <param name="vaultAccountId">The ID of the vault account to hide from the web console</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns the Vault Account to be visible in the web console.
        /// </summary>
        /// <param name="vaultAccountId">The ID of the vault account to be visible in the web console</param>
        /// <returns></returns>
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

        /// <summary>
        /// Retrieves all addresses of a specific asset inside a Fireblocks Vault Account.
        /// </summary>
        /// <param name="vaultAccountId">The ID of the vault account to return, or 'default' for the default vault account</param>
        /// <param name="assetId">The ID of the asset</param>
        /// <param name="EosAccountName">[optional] EOS account address</param>
        /// <returns></returns>
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
        public async Task<List<TransactionDetails>> ListTransactions(string before = null, string after = null, string status = null, string orderBy = null, string sourceType = null, string sourceId = null, string destType = null, string destId = null, string assets = null, string txHash = null, string limit = null)
        {
            try
            {
                string requestUri = $"/v1/transactions";
                List<TransactionDetails> transactionsDetails = await _fireblocksClient.GetAsync<List<TransactionDetails>>(requestUri);
                return transactionsDetails;
            }
            catch (Exception ex)
            {
                throw new FireblocksException(_messageErrorHttpClient, ex);
            }
        }
    }
}