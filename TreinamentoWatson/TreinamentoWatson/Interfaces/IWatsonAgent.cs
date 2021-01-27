using Domain.Modelos;
using Domain.Modelos.Watson;
using System.Threading.Tasks;

namespace TreinamentoWatson.Interfaces
{
    public interface IWatsonAgent
    {
        Task<OutputConversaWatson> EnviarMensagemAoWatson(InputConversaWatson mensagem);
    }
}
