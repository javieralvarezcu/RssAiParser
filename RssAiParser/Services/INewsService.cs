namespace RssAiParser.Services
{
    public interface INewsService
    {
        Task StoreNewsAsync(string rssUrl);
    }
}
