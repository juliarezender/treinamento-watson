using System.Threading.Tasks;

namespace Domain.Interfaces.Interface
{
    public interface IWatsonService
    {
        Task<string> EnviarMensagemAoWatson(string mensagem);
    }
}
