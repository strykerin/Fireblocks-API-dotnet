using Fireblocks.Authentication;
using Fireblocks.Exceptions;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Net.Http.Json;
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
    }
}
