using AppService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Util.Interfaces;
using System;
using System.Threading.Tasks;

namespace Watson.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Mensagem")]
    public class MensagemController : ControllerBase
    {
        private readonly IMensagemAppService _mensagemAppService;
        private readonly IApplicationInsights _applicationInsights;

        public MensagemController(IMensagemAppService mensagemAppService, IApplicationInsights applicationInsights)
        {
            _mensagemAppService = mensagemAppService;
            _applicationInsights = applicationInsights;
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<string>> ProcessarMensagem(string mensagemEntrada)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                return await _mensagemAppService.ProcessarMensagemAsync(mensagemEntrada);
            }
            catch (Exception ex)
            {
                _applicationInsights.EnviaException(ex);

                return StatusCode(500);
            }
        }
    }
}
