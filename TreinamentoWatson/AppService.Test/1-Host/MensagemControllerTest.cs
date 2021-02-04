using AppService.Interfaces;
using AutoFixture;
using Domain.Modelos;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Watson.Controllers;

namespace AppService.TestsUnitarios._1_Host
{
    class MensagemControllerTest
    {
        private Mock<IMensagemAppService> _mockMensagemAppService;
        private MensagemController _mensagemController;
        private Fixture _fixture;
        private MensagemEntrada mensagemEntrada;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _mockMensagemAppService = new Mock<IMensagemAppService>();
            _mensagemController = new MensagemController(_mockMensagemAppService.Object);
            mensagemEntrada = _fixture.Create<MensagemEntrada>();
        }

        [Test]
        public async Task TesteChamadaDoMetodoProcessarMensagemAsync()
        {
           await _mensagemController.ProcessarMensagem(mensagemEntrada);

            _mockMensagemAppService.Verify(mock => mock.ProcessarMensagemAsync(mensagemEntrada), Times.AtLeastOnce());

        }

        [Test]
        public async Task TesteExcecao()
        {
            await _mensagemController.ProcessarMensagem(mensagemEntrada);

            _mockMensagemAppService.Setup(mock => mock.ProcessarMensagemAsync(mensagemEntrada)).Throws(new Exception());

            Assert.ThrowsAsync<Exception>(() => _mensagemController.ProcessarMensagem(mensagemEntrada));
        }
    }
}
