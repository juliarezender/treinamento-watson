using AppService;
using AppService.Interfaces;
using Domain;
using Domain.Interfaces.Interface;
using Domain.Modelos;
using Microsoft.Extensions.DependencyInjection;
using System;
using TreinamentoWatson.Interfaces;
using TreinamentoWatson.Watson;

namespace IoC
{
    public class IocConfig
    {
        public static IServiceProvider ConfigureService(IServiceCollection services)
        {
            ConfigurarAppServices(services);
            ConfigurarServices(services);
            ConfigurarAgents(services);

            return services.BuildServiceProvider();
        }

        private static void ConfigurarAppServices(IServiceCollection services)
        {
            services
                .AddSingleton<IMensagemAppService, MensagemAppService>();
        }

        private static void ConfigurarServices(IServiceCollection services)
        {
            services
                .AddSingleton<IConversationService, ConversationService>()
                .AddSingleton<IWatsonService, WatsonService>();
        }

        private static void ConfigurarAgents(IServiceCollection services)
        {
            services
                 .AddSingleton<IWatsonAgent, WatsonAgent>()
                 .AddSingleton<IWatsonTokenAccessAgent, WatsonTokenAccessAgent>();
        }
    }
}
