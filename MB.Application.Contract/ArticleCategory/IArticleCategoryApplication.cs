namespace MB.Application.Contract.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        void Add(CreateArticleCategory command);
        void Rename(RenameArticleCategory command);
        List<ArticleCategoryViewModel> GetAll();
        RenameArticleCategory Get(long id);
        void Remove(long id);
        void Activate(long id);

    }
}
