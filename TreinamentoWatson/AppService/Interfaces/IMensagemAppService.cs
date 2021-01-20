using System.Threading.Tasks;

namespace AppService.Interfaces
{
    public interface IMensagemAppService
    {
        Task<string> ProcessarMensagemAsync(string mensagemEntrada);
    }
}
