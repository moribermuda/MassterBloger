namespace MB.Domain.ArticleAgg.Services
{
    public class ArticleServices : IArticleServices
    {
        private readonly IArticleRepository articleRepository;

        public ArticleServices(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public void CheckTitelIsExist(string title)
        {
            if (articleRepository.Exist(title))
                throw new DuplicateWaitObjectException();
        }
    }
}
