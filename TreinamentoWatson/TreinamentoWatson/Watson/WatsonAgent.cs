using Flurl;
using Flurl.Http;
using Polly;
using Shared.Util.Constantes;
using Shared.Util.Interfaces;
using System.Threading.Tasks;
using TreinamentoWatson.Interfaces;

namespace TreinamentoWatson.Watson
{
    public class WatsonAgent : IWatsonAgent
    {
        private readonly IWatsonTokenAccessAgent _tokenIntegracaoWatsonAgent;
        private readonly IApplicationSettings _config;
        public WatsonAgent(
            IWatsonTokenAccessAgent tokenIntegracaoWatsonAgent,
            IApplicationSettings config
        )
        {
            _tokenIntegracaoWatsonAgent = tokenIntegracaoWatsonAgent;
            _config = config;
        }

        public async Task<string> EnviarMensagemAoWatson(string mensagem)
        {
            var token = await _tokenIntegracaoWatsonAgent.GerarToken();

            return await Policy
                    .Handle<FlurlHttpException>()
                    .RetryAsync()
                    .ExecuteAsync(() =>
                            string.Format(_config.UrlBaseWatson)
                            .AppendPathSegment(ObterPath())
                            .SetQueryParam("version", _config.VersaoAssistant)
                            .WithOAuthBearerToken(token)
                            .PostJsonAsync(mensagem)
                            .ReceiveJson<string>()
                );
        }

        #region Métodos privados

        private string ObterPath()
        {
            return string.Format(
                // lembrar de trocar a rota
                Rotas.WatsonAgent.ENVIAR_MENSAGEM
            );
        }

        #endregion Métodos privados
    }


}
