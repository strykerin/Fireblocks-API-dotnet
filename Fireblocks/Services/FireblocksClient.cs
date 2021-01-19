using Fireblocks.Utils;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Net.Http.Headers;

namespace Fireblocks.Services
{
    public class FireblocksClient : IFireblocksClient
    {
        private const string _httpClientStatusCodeError = "Status code does not indicate success";
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _privateKey;
        public FireblocksClient(HttpClient httpClient, string apiKey, string privateKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
            _privateKey = privateKey;
        }

        public async Task<T> GetAsync<T>(string requestUri) where T : class
        {
            this.Authenticate(requestUri);
            T result = await _httpClient.GetFromJsonAsync<T>(requestUri);
            return result;
        }

        public async Task GetAsync(string requestUri)
        {
            this.Authenticate(requestUri);
            HttpResponseMessage response = await _httpClient.GetAsync(requestUri);
            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException(_httpClientStatusCodeError);
            }
            return;
        }

        public async Task<TReturn> PostAsync<TReturn, TBody>(string requestUri, TBody requestBody) where TReturn : class
                                                                                                   where TBody : class
        {
            this.Authenticate(requestUri);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(requestUri, requestBody);

            if (response.IsSuccessStatusCode)
            {
                TReturn result = await response.Content.ReadFromJsonAsync<TReturn>();
                return result;
            }
            else
            {
                throw new ArgumentException(_httpClientStatusCodeError);
            }
        }

        public async Task<TReturn> PostAsync<TReturn>(string requestUri) where TReturn : class
        {
            this.Authenticate(requestUri);
            HttpResponseMessage response = await _httpClient.PostAsync(requestUri, null);

            if (response.IsSuccessStatusCode)
            {
                TReturn result = await response.Content.ReadFromJsonAsync<TReturn>();
                return result;
            }
            else
            {
                throw new ArgumentException(_httpClientStatusCodeError);
            }
        }

        private void Authenticate(string requestUri)
        {
            string jwt = this.GenerateJWT(requestUri);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
        }

        private string GenerateJWT(string requestUri, string requestBody = "")
        {
            byte[] privateKeyByteArray = Convert.FromBase64String(_privateKey);
            using RSA rsa = RSA.Create();
            rsa.ImportPkcs8PrivateKey(privateKeyByteArray, out _);

            var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
            {
                CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
            };

            DateTime now = DateTime.Now;
            DateTimeOffset nowOffset = DateTimeOffset.Now;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("uri", requestUri),
                    new Claim("nonce", nowOffset.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                    new Claim("sub", _apiKey),
                    new Claim("bodyHash", CalculateHash.SHA256HashFunction(requestBody)),
                }),
                Expires = now.AddSeconds(55),
                NotBefore = now,
                SigningCredentials = signingCredentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
