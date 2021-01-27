using Domain.Interfaces.Interface;
using Domain.Modelos.Watson;
using System.Threading.Tasks;

namespace Domain.Modelos
{
    public class ConversationService : IConversationService
    {
        private readonly IWatsonService _watsonService;

        public ConversationService(IWatsonService watsonService)
        {
            _watsonService = watsonService;
        }
        public async Task<Mensagem> EnviarMensagemAoWatson(Mensagem mensagem)
        {
            var mensagemEntradaWatson = _watsonService.PreencherMensagemWatson(mensagem);

            var mensagemRespostaWatson = await _watsonService.EnviarMensagemAoWatson(mensagemEntradaWatson);

            var mensagemResposta = new Mensagem(mensagem, mensagemRespostaWatson);

            return mensagemResposta;
        }
    }
}
