using AppService.Interfaces;
using Domain.Interfaces.Interface;
using Domain.Modelos;
using Domain.Modelos.Watson;
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

        public async Task<MensagemSaida> ProcessarMensagemAsync(MensagemEntrada mensagemEntrada)
        {
            var mensagem = new Mensagem(mensagemEntrada);
            var mensagemResposta = await _conversationService.EnviarMensagemAoWatson(mensagem);

            return new MensagemSaida(mensagemResposta);
        }
    }
}
