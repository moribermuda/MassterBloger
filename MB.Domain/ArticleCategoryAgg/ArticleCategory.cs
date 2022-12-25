using _01_FrameWork.Domain;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : DomainBase<long>
    {

        public string Title { get;private set; }
        public bool IsDeleted { get;private set; }

        public ICollection<Article> Articles { get; set; }

        protected ArticleCategory()
        {
        }

        public ArticleCategory(string title,IArticleCategoryServices services)
        {
            services.CheckTitelIsExist(title);
            Title = title;
            IsDeleted = false;
            Articles = new List<Article>();
        }
        public void Rename(string title,IArticleCategoryServices services)
        {
            services.CheckTitelIsExist(title);
            Title = title;
        }
        public void Remove()
        {
            IsDeleted = true;
        }
        public void Restore()
        {
            IsDeleted = false;
        }
    }
}