using AppService.Interfaces;
using Domain.Modelos;
using Domain.Modelos.Watson;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Watson.Controllers
{
    [ApiController]
    [Route("api/v1/Mensagem")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class MensagemController : ControllerBase
    {
        private readonly IMensagemAppService _mensagemAppService;

        public MensagemController(IMensagemAppService mensagemAppService)
        {
            _mensagemAppService = mensagemAppService;
        }
        [HttpPost]
        public async Task<ActionResult<MensagemSaida>> ProcessarMensagem(MensagemEntrada mensagemEntrada)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                return await _mensagemAppService.ProcessarMensagemAsync(mensagemEntrada);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        //[Produces("application/json")]
        //[Consumes("application/json")]
        //[HttpGet]
        //public string ProcessarMensagem(string mensagemEntrada)
        //{
        //    mensagemEntrada = mensagemEntrada + " entrou ";

        //    return mensagemEntrada;
        //}
        //[Produces("application/json")]
        //[Consumes("application/json")]
        //[HttpGet]
        //public string Teste()
        //{
        //    return "Funcionou";
        //}
    }
}
