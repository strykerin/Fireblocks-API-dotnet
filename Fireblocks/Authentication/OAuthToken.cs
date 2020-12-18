using System.Security.Claims;
using System.Text.Json;
using Fireblocks.Utils;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Org.BouncyCastle.OpenSsl;
using System.IO;
using Org.BouncyCastle.Crypto;
using System.Security.Cryptography;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Parameters;
using System.Collections.Generic;
using System.Linq;

namespace Fireblocks.Authentication
{
    /// <summary>
    /// Base64-encoded JWT.
    /// The JWT should be signed with the private key and the RS256 (RSASSA-PKCS1-v1_5 using SHA-256 hash) algorithm.
    /// </summary>
    public class OAuthToken
    {
        public static string CreateSignedToken(string apiKey, string path, string privateKey, string httpRequestBody = "")
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey));
            //RSACryptoServiceProvider asymmetricSecurityKey = GetAsymmetricKey(@"C:\Users\fabio.costa\source\repos\UsingFireblocks\UsingFireblocks\Keys\fireblocks.key");

            var claims = new List<Claim>();
            claims.Add(new Claim("claim1", "value1"));
            claims.Add(new Claim("claim2", "value2"));
            claims.Add(new Claim("claim3", "value3"));
            var tokenTest = CreateToken(claims);


            string uri = path;
            long nonce = DateTimeOffset.Now.ToUnixTimeSeconds();
            string sub = apiKey;
            string bodyHash = CalculateHash.SHA256HashFunction(JsonSerializer.Serialize(httpRequestBody));

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor tokenDesciption = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(nameof(uri), uri),
                    new Claim(nameof(nonce), nonce.ToString()),
                    new Claim(nameof(sub), sub),
                    new Claim(nameof(bodyHash), bodyHash),
                }),
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddDays(7),
                NotBefore = DateTime.Now,
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.RsaSha256Signature) 
                { 
                    CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
                },
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDesciption);
            return tokenHandler.WriteToken(token);
        }

        private static string CreateToken(List<Claim> claims)
        {
            string privateKey = File.ReadAllText(@"C:\Users\fabio.costa\source\repos\UsingFireblocks\UsingFireblocks\Keys\fireblocks.key");
            StringReader str = new StringReader(privateKey);
            PemReader pr = new PemReader(str);
            AsymmetricCipherKeyPair keyPair = pr.ReadObject() as AsymmetricCipherKeyPair;
            RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)keyPair.Private);
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.ImportParameters(rsaParams);
            Dictionary<string, object> payload = claims.ToDictionary(k => k.Type, v => (object)v.Value);
            return Jose.JWT.Encode(payload, csp, Jose.JwsAlgorithm.RS256);
        }

        public static RSACryptoServiceProvider GetAsymmetricKey(string pathToPEM)
        {
            PemReader pr = new PemReader(new StringReader(pathToPEM));
            AsymmetricCipherKeyPair keyPair = (AsymmetricCipherKeyPair)pr.ReadObject();
            RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)keyPair.Private);
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.ImportParameters(rsaParams);
            return csp;
        }
    }
}
