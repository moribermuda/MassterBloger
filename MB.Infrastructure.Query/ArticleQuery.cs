using MB.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggContext context;

        public ArticleQuery(MasterBloggContext context)
        {
            this.context = context;
        }

        public ArticleQueryView Get(long id)
        {
            return context.articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Image = x.Image,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Content = x.Content,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleQueryView> GetArticles()
        {
            return context.articles.Include(x=>x.ArticleCategory).Select(x=>new ArticleQueryView
            {
                Id= x.Id,
                Title= x.Title,
                ShortDescription= x.ShortDescription,
                Image = x.Image,
                ArticleCategory=x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            }).ToList();
        }
    }
}
