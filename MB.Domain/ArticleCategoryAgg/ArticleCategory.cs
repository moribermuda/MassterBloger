using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreationDate { get; set; }

        public ArticleCategory(string title,IArticleCategoryServices services)
        {
            services.CheckTitelIsExist(title);
            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
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