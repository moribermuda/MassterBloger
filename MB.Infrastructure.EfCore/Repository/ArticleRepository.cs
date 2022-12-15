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

        public void CreatAndSave(Article article)
        {
           context.Add(article);
            Save();
        }

        public bool Exist(string title)
        {
            return context.articles.Any(a => a.Title == title);

        }

        public Article Get(long id)
        {
            return context.articles.FirstOrDefault(x => x.Id == id);
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

        public void Save()
        {
           context.SaveChanges();
        }
    }
}
