using AutoFixture;
using Domain.Modelos;
using Domain.Modelos.Watson;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using NUnit.Framework;
using Shared.Util.Interfaces;
using System.Threading.Tasks;
using TreinamentoWatson.Interfaces;
using TreinamentoWatson.Watson;

namespace Infra.Test
{
    public class WatsonAgentTest
    {
        private Fixture _fixture;
        private Mock<IApplicationSettings> _config;
        private Mock<IWatsonTokenAccessAgent> _mockWatsonAccessToken;
        private WatsonAgent _watsonAgent;
        private InputConversaWatson _inputConversaWatson;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _config = new Mock<IApplicationSettings>();
            _mockWatsonAccessToken = new Mock<IWatsonTokenAccessAgent>();
            _watsonAgent = new WatsonAgent(_mockWatsonAccessToken.Object, _config.Object);
            _inputConversaWatson = _fixture.Create<InputConversaWatson>();
        }

        [Test]
        public void TesteRetornoDaFuncaoEnviarMensagemAoWatson()
        {
            var instanceWatsonAgent = _watsonAgent.EnviarMensagemAoWatson(_inputConversaWatson);
            _mockWatsonAccessToken.Verify(mock => mock.ObterToken(), Times.AtLeastOnce);
            Assert.AreEqual(instanceWatsonAgent.GetType(), typeof(Task<OutputConversaWatson>));
        }
    }
    public class WatsonAccessAgentTokenTest
    {
        private Mock<IApplicationSettings> _config;
        private WatsonTokenAccessAgent _watsonAccessToken;
        private readonly IMemoryCache _memoryCache;

        [SetUp]
        public void Setup()
        {
            _config = new Mock<IApplicationSettings>();
            _watsonAccessToken = new WatsonTokenAccessAgent(_config.Object, _memoryCache);
        }

        //[Test]
        //public void TesteRetornoDaFuncaoObterToken()
        //{
        //    var instanceWatsonAccessToken = _watsonAccessToken.ObterToken();

        //    Assert.AreEqual(instanceWatsonAccessToken.GetType(), typeof(Task<string>));
        //}
    }
}