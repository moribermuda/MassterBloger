using MB.Application.Contract.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repository
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly MasterBloggContext context;

        public ArticleCategoryRepository(MasterBloggContext context)
        {
            this.context = context;
        }

        public void Create(ArticleCategory category)
        {
            context.articleCategories.Add(category);
            Save();
        }

        public bool Exist(string title)
        {
           return context.articleCategories.Any(x=>x.Title == title);
        }

        public ArticleCategory Get(long id)
        {
            return context.articleCategories.FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleCategoryViewModel> GetAll()
        {
            return context.articleCategories.Select(x=> new ArticleCategoryViewModel
            {
                Id=x.Id,
                Title=x.Title,
                IsDeleted=x.IsDeleted,
                CreationDate=x.CreationDate.ToString(),
            }).OrderByDescending(x=>x.Id).ToList();
          
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
