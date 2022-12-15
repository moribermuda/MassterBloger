namespace MB.Infrastructure.Query
{
    public interface IArticleQuery
    {
        ArticleQueryView Get(long id);
        List<ArticleQueryView> GetArticles();
    }
}
