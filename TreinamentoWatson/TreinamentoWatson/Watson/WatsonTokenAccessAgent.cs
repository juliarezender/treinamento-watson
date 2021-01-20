using Microsoft.Extensions.Caching.Memory;
using Shared.Util.Interfaces;
using System;
using System.Threading.Tasks;
using TreinamentoWatson.Interfaces;
using Domain.Modelos.Watson;
using Flurl.Http;
using Polly;
using Shared.Util.Constantes;

namespace TreinamentoWatson.Watson
{
    public class WatsonTokenAccessAgent : IWatsonTokenAccessAgent
    {
        private readonly IApplicationSettings _config;
        private readonly IMemoryCache _memoryCache;

        public WatsonTokenAccessAgent(IApplicationSettings config, IMemoryCache memoryCache)
        {
            _config = config;
            _memoryCache = memoryCache;

        }
        public async Task<string> GerarToken()
        {
            var token = await Policy
                .Handle<FlurlHttpException>()
                .RetryAsync()
                .ExecuteAsync(() =>
                        _config.UrlApiKeyWatson
                        .WithHeader("Accept", "application/json")
                        .PostUrlEncodedAsync(new
                        {
                            grant_type = "urn:ibm:params:oauth:grant-type:apikey",
                            apikey = _config.ApiKeyWatson
                        })
                        .ReceiveJson<AutenticacaoWatson>()
            );

            return _memoryCache.Set(CacheKeys.AccessTokenWatson, token).AccessToken;

        }
}
