using System.Threading.Tasks;

namespace TreinamentoWatson.Interfaces
{
    public interface IWatsonAgent
    {
        Task<string> EnviarMensagemAoWatson(string mensagem);
    }
}
