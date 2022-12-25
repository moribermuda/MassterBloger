using _01_FrameWork.Infrastructure;
using MB.Application.Contract.ArticleCategory;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IRepository<long,ArticleCategory>
    {
    }

}
