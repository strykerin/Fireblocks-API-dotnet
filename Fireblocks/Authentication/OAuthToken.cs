using System.Security.Claims;
using System.Text.Json;
using Fireblocks.Utils;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IO;
using System.Security.Cryptography;
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
    }
}
