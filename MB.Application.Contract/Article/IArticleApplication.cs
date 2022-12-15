namespace MB.Application.Contract.Article
{
    public interface IArticleApplication
    {
        void Create(CreateArticle command);       
        List<ArticleViewModel> GetList();
    }
}
