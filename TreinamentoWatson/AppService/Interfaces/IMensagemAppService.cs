using Domain.Modelos;
using Domain.Modelos.Watson;
using System.Threading.Tasks;

namespace AppService.Interfaces
{
    public interface IMensagemAppService
    {
        Task<MensagemSaida> ProcessarMensagemAsync(MensagemEntrada mensagemEntrada);
    }
}
