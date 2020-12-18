using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Fireblocks.Authentication;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;

namespace Fireblocks.Services
{
    public class FireblocksClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        public FireblocksClient(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        private void Authenticate()
        {
            //string jwt = 
            _httpClient.DefaultRequestHeaders.Add("X-API-Key", _apiKey);
            _httpClient.DefaultRequestHeaders.Add("Bearer", "");
        }

        private string GenerateJWT()
        {
            Header header = new Header
            {
                alg = "RS256",
                typ = "JWT"
            };
            Payload payload = new Payload
            {
                nameId = "123",
                nbf = 1608299468,
                exp = 1608904268,
                iat = 1608299468,
                iss = "http://mysite.com",
                aud = "http://myaudience.com"
            };

            byte[] bytesHeader = Encoding.UTF8.GetBytes(JsonSerializer.Serialize<Header>(header));
            byte[] bytesPayload = Encoding.UTF8.GetBytes(JsonSerializer.Serialize<Payload>(payload));

            string jwt = WebEncoders.Base64UrlEncode(bytesHeader) + "." + WebEncoders.Base64UrlEncode(bytesPayload);

            string signature = SignJWT(jwt);
            jwt = jwt + "." + signature;


            return jwt;
        }

        private string SignJWT(string jwt)
        {
            string privateKey = File.ReadAllText(@"C:\Users\fabio.costa\Downloads\fireblocks.key");
            byte[] privateKeyByte = Convert.FromBase64String(privateKey);

            using (RSA rsa = RSA.Create())
            {
                rsa.ImportPkcs8PrivateKey(privateKeyByte, out _);
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] jwtHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(jwt));
                    byte[] signature = rsa.SignHash(jwtHash, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    RSAPKCS1SignatureFormatter rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);
                    rsaFormatter.SetHashAlgorithm("SHA256");
                    byte[] signedHash = rsaFormatter.CreateSignature(jwtHash);
                    return WebEncoders.Base64UrlEncode(signedHash);
                }
            }
        }
    }
}
