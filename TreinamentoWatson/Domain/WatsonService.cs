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

        public WatsonService(IWatsonAgent watsonAgent)
        {
            _watsonAgent = watsonAgent;
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
                }
            };

            return conversaWatson;
        }
    }
}
