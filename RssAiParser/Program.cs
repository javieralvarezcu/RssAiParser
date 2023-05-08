// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RssAiParser.Context;
using RssAiParser.Repositories;
using RssAiParser.Services;

internal class Program
{
    static async Task Main(string[] args)
    {

        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        IConfiguration configuration = configurationBuilder.Build();
        // Configurar la inyección de dependencias
        var serviceProvider = new ServiceCollection()
            .AddScoped(typeof(INewsRepository), typeof(NewsRepository))
            .AddScoped(typeof(INewsService), typeof(NewsService))
            .AddDbContext<MyDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                )
            .BuildServiceProvider();

        // Obtener una instancia del servicio de noticias
        var newsService = serviceProvider.GetService<INewsService>();

        List<string> rssUris = new List<string>();

        rssUris.Add(@"https://feeds.elpais.com/mrss-s/pages/ep/site/elpais.com/portada");

        // Almacenar las noticias en la tabla OriginalNew
        foreach (var rss in rssUris)
        {
            await newsService?.StoreNewsAsync(rss);
        }
    }
}