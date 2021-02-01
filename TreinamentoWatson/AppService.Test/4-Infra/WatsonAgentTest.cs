using AutoFixture;
using Domain.Modelos;
using Domain.Modelos.Watson;
using FluentAssertions;
using Flurl;
using Flurl.Http;
using Flurl.Http.Testing;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using Shared.Util.Constantes;
using Shared.Util.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TreinamentoWatson.Interfaces;
using TreinamentoWatson.Watson;

namespace AppService.TestsUnitarios._4_Infra
{
    public class WatsonAgentTest
    {
        private Fixture _fixture;
        private Mock<IApplicationSettings> _config;
        private Mock<IWatsonTokenAccessAgent> _mockWatsonAccessToken;
        private WatsonAgent _watsonAgent;
        private InputConversaWatson _inputConversaWatson;
        private HttpTest _httpTest;


        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _config = new Mock<IApplicationSettings>();
            _mockWatsonAccessToken = new Mock<IWatsonTokenAccessAgent>();
            _watsonAgent = new WatsonAgent(_mockWatsonAccessToken.Object, _config.Object);
            _inputConversaWatson = _fixture.Create<InputConversaWatson>();
            _httpTest = new HttpTest();

        }

        [TearDown]
        public void DisposeHttpTest()
        {
            _httpTest.Dispose();
        }
        [Test]
        public void TesteRetornoDaFuncaoEnviarMensagemAoWatson()
        {
            var instanceWatsonAgent = _watsonAgent.EnviarMensagemAoWatson(_inputConversaWatson);
            _mockWatsonAccessToken.Verify(mock => mock.ObterToken(), Times.AtLeastOnce);
            Assert.AreEqual(instanceWatsonAgent.GetType(), typeof(Task<OutputConversaWatson>));
        }

        [Test]
        public async Task TesteFlurlChamadaCorreta()
        {
            var accessToken = _fixture.Create<string>();
            var mensagemRequest = _fixture.Create<InputConversaWatson>();
            var mensagemReponse = _fixture.Create<OutputConversaWatson>();
            _config.Setup(mock => mock.ApiKeyWatson).Returns(_fixture.Create<string>());
            _config.Setup(mock => mock.UrlBaseWatson).Returns(_fixture.Create<Uri>().ToString());
            _config.Setup(mock => mock.VersaoAssistant).Returns(_fixture.Create<string>());

            _mockWatsonAccessToken.Setup(mock => mock.ObterToken()).ReturnsAsync(accessToken);

            await _watsonAgent.EnviarMensagemAoWatson(mensagemRequest);

            var url = string.Format(_config.Object.UrlBaseWatson, _config.Object.WatsonInstanceId)
                      .AppendPathSegment(Rotas.WatsonAgent.ENVIAR_MENSAGEM)
                      .SetQueryParam("version", _config.Object.VersaoAssistant);

            _httpTest.ShouldHaveCalled(url.ToString());
        }

        [Test]
        public async Task TesteFlurlChamadaIncorreta()
        {
            var accessToken = _fixture.Create<string>();
            var mensagemRequest = _fixture.Create<InputConversaWatson>();
            var mensagemReponse = _fixture.Create<OutputConversaWatson>();
            _config.Setup(mock => mock.ApiKeyWatson).Returns(_fixture.Create<string>());
            _config.Setup(mock => mock.UrlBaseWatson).Returns(_fixture.Create<Uri>().ToString());
            _config.Setup(mock => mock.VersaoAssistant).Returns(_fixture.Create<string>());

            _mockWatsonAccessToken.Setup(mock => mock.ObterToken()).ReturnsAsync(accessToken);

            await _watsonAgent.EnviarMensagemAoWatson(mensagemRequest);

            var url = string.Format(_config.Object.UrlBaseWatson, _config.Object.WatsonInstanceId)
                      .AppendPathSegment(Rotas.WatsonAgent.ENVIAR_MENSAGEM);

            _httpTest.ShouldNotHaveCalled(url.ToString());
        }
    }
}
