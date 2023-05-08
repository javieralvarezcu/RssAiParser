using System.ServiceModel.Syndication;
using System.Xml;

namespace RssAiParser.Repositories
{
    public class NewsRepository : INewsRepository
    {
        public async Task<IEnumerable<SyndicationItem>> GetNewsAsync(string rssUrl)
        {
            var newsItems = new List<SyndicationItem>();

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(rssUrl);
                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();
                    var xmlReader = XmlReader.Create(new System.IO.StringReader(content));
                    var feed = SyndicationFeed.Load(xmlReader);

                    newsItems = feed.Items.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al recuperar noticias: {ex.Message}");
                }
            }

            return newsItems;
        }
    }
}
