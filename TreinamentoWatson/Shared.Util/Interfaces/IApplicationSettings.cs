namespace Shared.Util.Interfaces
{
    public interface IApplicationSettings
    {
        string UrlBaseWatson { get; }
        string ApiKeyWatson { get; }
        string UrlApiKeyWatson { get; }
        string VersaoAssistant { get; }
        string WatsonInstanceId { get; }
        string WatsonAssistantId { get; }


    }
}
