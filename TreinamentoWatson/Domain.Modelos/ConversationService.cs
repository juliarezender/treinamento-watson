using Domain.Interfaces.Interface;
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
        public async Task<string> EnviarMensagemAoWatson(string mensagem)
        {
            var mensagemRespostaWatson = await _watsonService.EnviarMensagemAoWatson(mensagem);

            return mensagemRespostaWatson;
        }
    }
}
