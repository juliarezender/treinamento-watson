using AutoFixture;
using Domain.Modelos.Watson;
using FluentAssertions;
using Flurl.Http.Testing;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using NUnit.Framework;
using Shared.Util.Constantes;
using Shared.Util.Interfaces;
using System;
using System.Threading.Tasks;
using TreinamentoWatson.Watson;

namespace AppService.TestsUnitarios._4_Infra
{
    class WatsonAccessAgentTokenTest
    {
        private Mock<IApplicationSettings> _config;
        private Mock<ICacheEntry> _cacheEntryMock;
        private WatsonTokenAccessAgent _watsonAccessToken;
        private Mock<IMemoryCache> _memoryCache;
        private Fixture _fixture;
        private HttpTest _httpTest;


        [SetUp]
        public void Setup()
        {
            _memoryCache = new Mock<IMemoryCache>();
            _config = new Mock<IApplicationSettings>();
            _watsonAccessToken = new WatsonTokenAccessAgent(_config.Object, _memoryCache.Object);
            _httpTest = new HttpTest();
            _fixture = new Fixture();
            _cacheEntryMock = new Mock<ICacheEntry>();

            _config.Setup(c => c.UrlApiKeyWatson).Returns(_fixture.Create<Uri>().ToString());

            _config.Setup(c => c.ApiKeyWatson).Returns(_fixture.Create<string>());

            _memoryCache.Setup(cache => cache.CreateEntry(CacheKeys.AccessTokenWatson)).Returns(_cacheEntryMock.Object);
        }

        [TearDown]
        public void DisposeHttpTest()
        {
            _httpTest.Dispose();
        }

        [Test]
        public async Task DeveGerarTokenCasoNaoExistaNoCache()
        {
            var token = _fixture.Create<AutenticacaoWatson>();

            _httpTest.RespondWithJson(token);

            var instanciaWatsonAccessToken = await _watsonAccessToken.ObterToken();

            instanciaWatsonAccessToken.Should().Be(token.AccessToken);

        }
    }
}