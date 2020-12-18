using System.IO;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using Fireblocks.Parameters;

namespace Fireblocks.Extensions
{
    public static class FireblocksExtension
    {
        /// <summary>
        /// Extension method to Add the IFireblocks into DI container
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="apiKey">API Key to access Fireblocks</param>
        public static void AddFireblocks(this IServiceCollection services, string apiKey, string pathToPEMFile)
        {
            string privateKey = File.ReadAllText(pathToPEMFile);
            services.AddHttpClient("Fireblocks", httpClient =>
            {
                httpClient.BaseAddress = new Uri(FireblocksParameters.BaseAddress);
                httpClient.DefaultRequestHeaders.Add("X-API-Key", apiKey);
            });

            services.AddScoped<IFireblocks>(ctx =>
            {
                var clientFactory = ctx.GetRequiredService<IHttpClientFactory>();
                var httpClient = clientFactory.CreateClient("Fireblocks");

                return new Fireblocks(apiKey, privateKey, httpClient);
            });
        }
    }
}
