using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreationDate { get; set; }
        public ICollection<Article> articles { get; set; }

        protected ArticleCategory()
        {
        }

        public ArticleCategory(string title,IArticleCategoryServices services)
        {
            services.CheckTitelIsExist(title);
            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            articles = new List<Article>();
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