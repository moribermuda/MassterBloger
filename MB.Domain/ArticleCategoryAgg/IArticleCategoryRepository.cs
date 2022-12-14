using MB.Application.Contract.ArticleCategory;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategoryViewModel> GetAll();
        void Create(ArticleCategory category);
        ArticleCategory Get(long id);
        void Save();
        bool Exist(string title);
    }

}
