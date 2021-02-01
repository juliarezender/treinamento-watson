using AutoMapper;
using Domain.Interfaces.Interface;
using Domain.Modelos;
using Domain.Modelos.Watson;
using Flurl.Http;
using System;
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
            catch(Exception)
            {
                throw new Exception();
            }

        }
        public InputConversaWatson PreencherMensagemWatson(Mensagem mensagem)
        {
            var conversaWatson = new InputConversaWatson
            {
                Input = new UserInput
                {
                    Texto = mensagem.Texto
                }
            };

            return conversaWatson;
        }
    }
}
