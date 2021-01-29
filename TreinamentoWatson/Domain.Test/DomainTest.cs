using AutoFixture;
using AutoMapper;
using Domain.Interfaces.Interface;
using Domain.Modelos;
using Domain.Modelos.Watson;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TreinamentoWatson.Interfaces;

namespace Domain.Test
{
    public class ConversationServiceTest
    {
        private Fixture _fixture;
        private Mock<IWatsonService> _mockWatsonService;
        private ConversationService conversationService;
        private Mensagem _mensagem;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _mockWatsonService = new Mock<IWatsonService>();
            conversationService = new ConversationService(_mockWatsonService.Object);
            _mensagem = _fixture.Create<Mensagem>();
        }

        [Test]
        public void TesteRetornoDaFuncaoDeConversationService()
        {
            var instanceConversationService = conversationService.EnviarMensagemAoWatson(_mensagem);

            _mockWatsonService.Verify(mock => mock.PreencherMensagemWatson(_mensagem), Times.AtLeastOnce);

            Assert.AreEqual(instanceConversationService.GetType(), typeof(Task<Mensagem>));
        }
    }

    public class WatsonServiceTest
    {
        private Fixture _fixture;
        private readonly IMapper _mapper;
        private Mock<IWatsonAgent> _mockWatsonAgent;
        private WatsonService _watsonService;
        private InputConversaWatson _inputConversaWatson;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _mockWatsonAgent = new Mock<IWatsonAgent>();
            _watsonService = new WatsonService(_mockWatsonAgent.Object, _mapper);
            _inputConversaWatson = _fixture.Create<InputConversaWatson>();

        }

        [Test]
        public void TesteRetornoDaFuncaoDeWatsonService()
        {
            var _instanceWatsonService = _watsonService.EnviarMensagemAoWatson(_inputConversaWatson);

            _mockWatsonAgent.Verify(mock => mock.EnviarMensagemAoWatson(_inputConversaWatson), Times.AtLeastOnce);

            Assert.AreEqual(_instanceWatsonService.GetType(), typeof(Task<OutputConversaWatson>));
        }

        //[Test]
        //public void TesteExcecaoDaFuncaoDeWatsonService()
        //{
        //    //var _instanceWatsonService = _watsonService.EnviarMensagemAoWatson(_inputConversaWatson);

        //    _mockWatsonAgent.Setup(mock => mock.EnviarMensagemAoWatson(_inputConversaWatson)).Throws(new Exception());

        //    Assert.Throws<Exception>(() => _watsonService.EnviarMensagemAoWatson(_inputConversaWatson));
        //}
    }
}