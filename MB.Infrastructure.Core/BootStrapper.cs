using MB.Application;
using MB.Application.Contract.Article;
using MB.Application.Contract.ArticleCategory;
using MB.Application.Contract.Comment;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EfCore;
using MB.Infrastructure.EfCore.Repository;
using MB.Infrastructure.Query;
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
            service.AddTransient<IArticleServices, ArticleServices>();

            service.AddTransient<IArticleQuery, ArticleQuery>();

            service.AddTransient<ICommentApplication, CommentApplication>();
            service.AddTransient<ICommentRepository, CommentRepository>();
            service.AddDbContext<MasterBloggContext>(x => x.UseSqlServer(connectionString));
        }
    }
}