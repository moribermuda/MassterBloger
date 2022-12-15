using MB.Application.Contract.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public void Create(CreateArticle command)
        {
            var Article = new Article(command.Title,command.ShortDescription,command.Image,command.Content,command.ArticleCategoryId);
            articleRepository.CreatAndSave(Article);
        }

        public List<ArticleViewModel> GetList()
        {
            return articleRepository.GetList();
        }
    }
}
