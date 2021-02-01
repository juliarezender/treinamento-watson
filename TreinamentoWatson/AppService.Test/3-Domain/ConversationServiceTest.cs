using AutoFixture;
using Domain.Interfaces.Interface;
using Domain.Modelos;
using Domain.Modelos.Watson;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace AppService.TestsUnitarios._3_Domain
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
}
