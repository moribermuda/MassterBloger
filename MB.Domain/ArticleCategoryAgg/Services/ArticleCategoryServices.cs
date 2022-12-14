namespace MB.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryServices : IArticleCategoryServices
    {
        private readonly IArticleCategoryRepository categoryRepository;

        public ArticleCategoryServices(IArticleCategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public void CheckTitelIsExist(string title)
        {
            if (categoryRepository.Exist(title))
                throw new DuplicateWaitObjectException("This Record : "+title+" is Already Exist In DateBase");
        }
    }
}
