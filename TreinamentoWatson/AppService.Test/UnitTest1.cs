using AppService.Interfaces;
using AutoFixture;
using Domain.Interfaces.Interface;
using Domain.Modelos;
using Domain.Modelos.Watson;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace AppService.Test
{
    public class Tests
    {
        private Fixture _fixture;
        private Mock<IConversationService> _mockConversationService;
        private MensagemAppService appService;
        private MensagemEntrada _mensagemEntrada;
        private Task<MensagemSaida> _mensagemSaida;
        private Task<Mensagem> _mensagem;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _mockConversationService = new Mock<IConversationService>();
            appService = new MensagemAppService(_mockConversationService.Object);
            _mensagemEntrada = _fixture.Create<MensagemEntrada>();
            _mensagemSaida = _fixture.Create<Task<MensagemSaida>>();
            _mensagem = _fixture.Create<Task<Mensagem>>();
        }

        [Test]
        public void Test1()
        {
            //_mockConversationService.Setup(mock => mock.EnviarMensagemAoWatson(It.IsAny<Mensagem>())).Returns(_mensagem);
            var instanceAppService = appService.ProcessarMensagemAsync(_mensagemEntrada);
            // It.IsAny<T> is checking that the parameter is of type T, it can be any instance of type T. It's basically saying,
            // I don't care what you pass in here as long as it is type of T.

            _mockConversationService.Verify(mock => mock.EnviarMensagemAoWatson(It.IsAny<Mensagem>()), Times.AtLeastOnce());
            Assert.AreEqual(instanceAppService.GetType(), typeof(Task<MensagemSaida>));
        }
    }
}