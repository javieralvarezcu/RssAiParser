using RssAiParser.Context;
using RssAiParser.Models;
using RssAiParser.Repositories;

namespace RssAiParser.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly MyDbContext _dbContext;

        public NewsService(INewsRepository newsRepository, MyDbContext dbContext)
        {
            _newsRepository = newsRepository;
            _dbContext = dbContext;
        }

        public async Task StoreNewsAsync(string rssUrl)
        {
            var newsItems = await _newsRepository.GetNewsAsync(rssUrl);

            foreach (var item in newsItems)
            {
                var originalNew = new OriginalNew
                {
                    Url = item.Links.FirstOrDefault()?.Uri.ToString(),
                    Titular = item.Title.Text,
                    Subtitulo = item.Summary?.Text,
                    Cuerpo = item.Content?.ToString(),
                    ProdDate = item.PublishDate.DateTime
                };

                _dbContext.OriginalNews.Add(originalNew);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
