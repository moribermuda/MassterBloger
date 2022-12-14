using MB.Application.Contract.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository articleCategoryRepository;
        private readonly IArticleCategoryServices categorySrvices;
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryServices categorySrvices)
        {
            this.articleCategoryRepository = articleCategoryRepository;
            this.categorySrvices = categorySrvices;
        }

        public void Add(CreateArticleCategory command)
        {
            var articleCategory = new ArticleCategory(command.Title, categorySrvices);
            articleCategoryRepository.Create(articleCategory);
            articleCategoryRepository.Save();
        }

        public List<ArticleCategoryViewModel> GetAll()
        {
            return articleCategoryRepository.GetAll();
        }

        public void Rename(RenameArticleCategory command)
        {
            var ArticleCategory = articleCategoryRepository.Get(command.Id);
            ArticleCategory.Rename(command.Title,categorySrvices);
            articleCategoryRepository.Save();
        }

        public RenameArticleCategory Get(long id)
        {
            var category = articleCategoryRepository.Get(id);
            return new RenameArticleCategory
            {
                Id = category.Id,
                Title = category.Title,
            };
        }

        public void Remove(long id)
        {
            var category = articleCategoryRepository.Get(id);
            category.Remove();
            articleCategoryRepository.Save();
        }

        public void Activate(long id)
        {
            var category = articleCategoryRepository.Get(id);
            category.Restore();
            articleCategoryRepository.Save();
        }
    }
}
