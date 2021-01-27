using System.Threading.Tasks;

namespace TreinamentoWatson.Interfaces
{
    public interface IWatsonTokenAccessAgent
    {
        Task<string> ObterToken();

    }
}
