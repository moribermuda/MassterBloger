using MB.Application.Contract.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MB.Infrastructure.EfCore.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MasterBloggContext context;

        public ArticleRepository(MasterBloggContext context)
        {
            this.context = context;
        }

        public List<ArticleViewModel> GetList()
        {
           return context.articles.Include(x=>x.ArticleCategory).Select(x => new ArticleViewModel
            {
                Id= x.Id,
                Title= x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                IsDeleted= x.IsDeleted,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            }).ToList();
        }
    }
}
