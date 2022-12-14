using MB.Application;
using MB.Application.Contract.Article;
using MB.Application.Contract.ArticleCategory;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Infrastructure.EfCore;
using MB.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.Core
{
    public class BootStrapper
    {
        public static void Config(IServiceCollection service,string connectionString)
        {
            service.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            service.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            service.AddTransient<IArticleCategoryServices, ArticleCategoryServices>();

            service.AddTransient<IArticleApplication, ArticleApplication>();
            service.AddTransient<IArticleRepository, ArticleRepository>();
            service.AddDbContext<MasterBloggContext>(x => x.UseSqlServer(connectionString));
        }
    }
}