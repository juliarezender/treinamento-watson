using System.Threading.Tasks;

namespace Domain.Interfaces.Interface
{
    public interface IConversationService
    {
        Task<string> EnviarMensagemAoWatson(string mensagem);
    }
}
