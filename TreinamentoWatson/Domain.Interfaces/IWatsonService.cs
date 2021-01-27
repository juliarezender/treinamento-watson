using System.Threading.Tasks;
using Domain.Modelos;
using Domain.Modelos.Watson;

namespace Domain.Interfaces.Interface
{
    public interface IWatsonService
    {
        InputConversaWatson PreencherMensagemWatson(Mensagem mensagem);
        Task<OutputConversaWatson> EnviarMensagemAoWatson(InputConversaWatson mensagem);
    }
}
