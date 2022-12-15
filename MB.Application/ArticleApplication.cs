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

        public void Edit(EditArticle command)
        {
            var Article = articleRepository.Get(command.Id);
            Article.Edit(command.Title,command.ShortDescription,command.Image,command.Content,command.ArticleCategoryId);
            articleRepository.Save();
        }

        public EditArticle Get(long id)
        {
           var article = articleRepository.Get(id);
            return new EditArticle { 
             Id=article.Id,
             Title= article.Title,
             ShortDescription= article.ShortDescription,
             Image= article.Image,
             Content= article.Content,
             ArticleCategoryId = article.ArticleCategoryId,
            };
        }

        public List<ArticleViewModel> GetList()
        {
            return articleRepository.GetList();
        }

        public void Remove(long id)
        {
            var article = articleRepository.Get(id);
            article.Remove();
            articleRepository.Save();
        }
        public void Activate(long id)
        {
            var article = articleRepository.Get(id);
            article.Activate();
            articleRepository.Save();
        }

    }
}
