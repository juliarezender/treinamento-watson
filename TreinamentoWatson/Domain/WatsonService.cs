using AutoMapper;
using Domain.Interfaces.Interface;
using Domain.Modelos;
using Domain.Modelos.Watson;
using Flurl.Http;
using System.Threading.Tasks;
using TreinamentoWatson.Interfaces;

namespace Domain
{
    public class WatsonService : IWatsonService
    {
        private readonly IWatsonAgent _watsonAgent;
        private readonly IMapper _mapper;

        public WatsonService(IWatsonAgent watsonAgent, IMapper mapper)
        {
            _watsonAgent = watsonAgent;
            _mapper = mapper;
        }
        public async Task<OutputConversaWatson> EnviarMensagemAoWatson(InputConversaWatson mensagem)
        {
            try
            {
                var mensagemRespostaWatson = await _watsonAgent.EnviarMensagemAoWatson(mensagem);
                return mensagemRespostaWatson;
            }
            catch (FlurlHttpTimeoutException)
            {
                throw;
            }
            catch (FlurlHttpException ex)
            {
                var statusCode = await ex.GetResponseJsonAsync<OutputConversaWatson>();
                throw;
            }
        }
        public InputConversaWatson PreencherMensagemWatson(Mensagem mensagem)
        {
            var conversaWatson = new InputConversaWatson
            {
                Input = new UserInput
                {
                    Texto = mensagem.Texto
                },
                //Context = new MessageContext
                //{
                //    Global = new MessageContextGlobal
                //    {
                //        System = new MessageContextGlobalSystem { UserId = mensagem.Contexto.IdUsuario },
                //        SessionId = mensagem.Contexto.SessionId
                //    },
                //    Skills = new MessageContextSkills
                //    {
                //        MainSkillContext = _mapper.Map<MainSkillContext>(mensagem.Contexto)
                //    }
                //},
            };

            return conversaWatson;
        }
    }
}
