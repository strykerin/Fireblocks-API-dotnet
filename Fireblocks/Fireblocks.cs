using Fireblocks.Authentication;
using Fireblocks.Exceptions;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using Fireblocks.Entities;

namespace Fireblocks
{
    public class Fireblocks : IFireblocks
    {
        private const string _messageErrorHttpClient = "There was an error in HttpClient";

        private readonly string _apiKey;
        private readonly string _privateKey;
        private readonly HttpClient _httpClient;

        public Fireblocks(string apiKey, string privateKey, HttpClient httpClient)
        {
            _apiKey = apiKey;
            _privateKey = privateKey;
            _httpClient = httpClient;
        }

        /// <summary>
        /// Returns all accounts of the active Vault
        /// </summary>
        /// <returns>
        /// Returns an array of VaultAccount objects.
        /// </returns>
        public async Task<VaultAccount> GetVault()
        {
            try
            {
                string requestUri = "vault/accounts";

                SetAuthenticationHeader(requestUri);
                VaultAccount vaultAccount = await _httpClient.GetFromJsonAsync<VaultAccount>(requestUri);
                return vaultAccount;
            }
            catch (Exception ex)
            {
                throw new FireblocksException(_messageErrorHttpClient, ex);
            }
        }

        private void SetAuthenticationHeader(string path)
        {
            string jwt = OAuthToken.CreateSignedToken(_apiKey, path, _privateKey);
            bool removed = _httpClient.DefaultRequestHeaders.Remove("Bearer");
            if (!removed)
            {
                throw new Exception("Header not found");
            }

            _httpClient.DefaultRequestHeaders.Add("Bearer", jwt);
        }
    }
}
