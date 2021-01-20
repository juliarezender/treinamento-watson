using AppService.Interfaces;
using Domain.Interfaces.Interface;
using System;
using System.Threading.Tasks;

namespace AppService
{
    public class MensagemAppService : IMensagemAppService
    {
        private readonly IConversationService _conversationService;

        public MensagemAppService(IConversationService conversationService)
        {
            _conversationService = conversationService;
        }

        public async Task<string> ProcessarMensagemAsync(string mensagemEntrada)
        {
            var mensagemResposta = await _conversationService.EnviarMensagemAoWatson(mensagemEntrada);

            return mensagemResposta;
        }
    }
}
