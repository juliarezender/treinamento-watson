using AutoFixture;
using Domain;
using Domain.Modelos;
using Domain.Modelos.Watson;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TreinamentoWatson.Interfaces;

namespace AppService.TestsUnitarios._3_Domain
{
    public class WatsonServiceTest
    {
        private Fixture _fixture;
        private Mock<IWatsonAgent> _mockWatsonAgent;
        private WatsonService _watsonService;
        private InputConversaWatson _inputConversaWatson;
        private Mensagem _mensagem;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _mockWatsonAgent = new Mock<IWatsonAgent>();
            _watsonService = new WatsonService(_mockWatsonAgent.Object);
            _inputConversaWatson = _fixture.Create<InputConversaWatson>();
            _mensagem = _fixture.Create<Mensagem>();

        }

        [Test]
        public void TesteRetornoDaFuncaoDeWatsonService()
        {
            var _instanceWatsonService = _watsonService.EnviarMensagemAoWatson(_inputConversaWatson);

            _mockWatsonAgent.Verify(mock => mock.EnviarMensagemAoWatson(_inputConversaWatson), Times.AtLeastOnce);

            Assert.AreEqual(_instanceWatsonService.GetType(), typeof(Task<OutputConversaWatson>));
        }

        [Test]
        public void TesteExcecaoDaFuncaoDeWatsonService()
        {
            _mockWatsonAgent.Setup(mock => mock.EnviarMensagemAoWatson(_inputConversaWatson)).Throws(new Exception());

            Assert.ThrowsAsync<Exception>(() =>  _watsonService.EnviarMensagemAoWatson(_inputConversaWatson));
        }

        [Test]
        public void TestePreencherMensagemWatson()
        {
            var chamadaPreencherMensagemWatson = _watsonService.PreencherMensagemWatson(_mensagem);

            Assert.AreEqual(chamadaPreencherMensagemWatson.GetType(), typeof(InputConversaWatson));
        }
    }
}