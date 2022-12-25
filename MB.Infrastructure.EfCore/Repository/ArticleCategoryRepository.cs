using _01_FrameWork.Infrastructure;
using MB.Application.Contract.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
namespace MB.Infrastructure.EfCore.Repository
{
    public class ArticleCategoryRepository :BaseRepository<long,ArticleCategory>, IArticleCategoryRepository
    {
        private readonly MasterBloggContext context;

        public ArticleCategoryRepository(MasterBloggContext context) : base(context) 
        {
            this.context = context;
        }
    }
}
