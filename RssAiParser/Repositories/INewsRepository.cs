using System.ServiceModel.Syndication;

namespace RssAiParser.Repositories
{
    public interface INewsRepository
    {
        Task<IEnumerable<SyndicationItem>> GetNewsAsync(string rssUrl);
    }
}
