using AutoMapper;
using Domain.Interfaces.Interface;
using Flurl.Http;
using Shared.Util.Interfaces;
using System.Threading.Tasks;
using TreinamentoWatson.Interfaces;

namespace Domain
{
    public class WatsonService : IWatsonService
    {
        private readonly IWatsonAgent _watsonAgent;
        private readonly IMapper _mapper;
        private readonly IApplicationInsights _applicationInsights;

        public WatsonService(IWatsonAgent watsonAgent, IMapper mapper, IApplicationInsights applicationInsights)
        {
            _watsonAgent = watsonAgent;
            _mapper = mapper;
            _applicationInsights = applicationInsights;
        }
        public async Task<string> EnviarMensagemAoWatson(string mensagem)
        {
            try
            {
                var mensagemRespostaWatson = await _watsonAgent.EnviarMensagemAoWatson(mensagem);
                return mensagemRespostaWatson;
            }
            catch (FlurlHttpTimeoutException ex)
            {
                _applicationInsights.EnviaException(ex);
                throw;
            }
            catch (FlurlHttpException ex)
            {
                _applicationInsights.EnviaException(ex);
                throw;
            }
        }
    }
}
