using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using Fireblocks.Parameters;
using Fireblocks.Services;

namespace Fireblocks.Extensions
{
    public static class FireblocksExtension
    {
        /// <summary>
        /// Extension method to Add the IFireblocks into DI container
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="apiKey">API Key to access Fireblocks</param>
        public static void AddFireblocks(this IServiceCollection services, string apiKey)
        {
            services.AddHttpClient("Fireblocks", httpClient =>
            {
                httpClient.BaseAddress = new Uri(FireblocksParameters.BaseAddress);
                httpClient.DefaultRequestHeaders.Add("X-API-Key", apiKey);
            });

            services.AddScoped<IFireblocksClient>(ctx =>
            {
                var clientFactory = ctx.GetRequiredService<IHttpClientFactory>();
                var httpClient = clientFactory.CreateClient("Fireblocks");

                return new FireblocksClient(httpClient, apiKey);
            });

            services.AddScoped<IFireblocks>(ctx =>
            {
                var fireblocksClient = ctx.GetRequiredService<IFireblocksClient>();
                return new Fireblocks(fireblocksClient);
            });
        }
    }
}