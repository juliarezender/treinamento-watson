using Microsoft.Extensions.Caching.Memory;
using Shared.Util.Interfaces;
using System.Threading.Tasks;
using TreinamentoWatson.Interfaces;
using Domain.Modelos.Watson;
using Flurl.Http;
using Polly;
using Shared.Util.Constantes;
using System;

namespace TreinamentoWatson.Watson
{
    public class WatsonTokenAccessAgent : IWatsonTokenAccessAgent
    {
        private readonly IApplicationSettings _config;
        private readonly IMemoryCache _memoryCache;
        private const double fracaoTempoMaximoDeVidaToken = 0.8;

        public WatsonTokenAccessAgent(IApplicationSettings config, IMemoryCache memoryCache)
        {
            _config = config;
            _memoryCache = memoryCache;

        }

        public Task<string> ObterToken()
        {
            if (_memoryCache.TryGetValue(CacheKeys.AccessTokenWatson, out AutenticacaoWatson token))
            {
                // Expirando o token antes do previsto garante que não será usado um token inválido
                var expiracaoLimite = token.Expiration - ((1 - fracaoTempoMaximoDeVidaToken) * token.ExpiresIn);

                if (DateTimeOffset.UtcNow.ToUnixTimeSeconds() >= expiracaoLimite)
                {
                    return GerarToken();
                }
                else
                {
                    return Task.FromResult(token.AccessToken);
                }
            }

            return GerarToken();
        }

        private async Task<string> GerarToken()
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
}

