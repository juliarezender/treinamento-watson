using Domain.Modelos.Watson;
using System.Threading.Tasks;

namespace Domain.Interfaces.Interface
{
    public interface IConversationService
    {
        Task<Mensagem> EnviarMensagemAoWatson(Mensagem mensagem);
    }
}
