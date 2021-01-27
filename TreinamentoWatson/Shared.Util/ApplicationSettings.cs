using Microsoft.Extensions.Configuration;
using Shared.Util.Interfaces;

namespace Shared.Util
{
    public class ApplicationSettings : IApplicationSettings
    {
        private readonly IConfigurationSection _configuracoesApp;
        private readonly IConfigurationSection _chavesResolver;
        private readonly IConfiguration _configApp;

        public ApplicationSettings(IConfiguration configuracoes)
        {
            _configuracoesApp = configuracoes.GetSection("AppConfiguration");
            _chavesResolver = configuracoes.GetSection("ResolverConfig");
            _configApp = configuracoes;
        }

        #region Watson

        public string UrlBaseWatson => _configuracoesApp.GetValue<string>("UrlBaseWatson");
        public string ApiKeyWatson => _configuracoesApp.GetValue<string>("ApiKeyWatson");
        public string UrlApiKeyWatson => _configuracoesApp.GetValue<string>("UrlApiKeyWatson");
        public string VersaoAssistant => _configuracoesApp.GetValue<string>("VersaoAssistant");
        public string WatsonAssistantId => _configuracoesApp.GetValue<string>("WatsonAssistantId");
        public string WatsonInstanceId => _configuracoesApp.GetValue<string>("WatsonInstanceId");


        #endregion

    }
}

