using MB.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.CategoryManage
{
    public class CreateModel : PageModel
    {
        private readonly IArticleCategoryApplication articleCategoryApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            this.articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
        }
        public RedirectToPageResult OnPost(CreateArticleCategory command)
        {
            articleCategoryApplication.Add(command);
            return RedirectToPage("./List");
        }
    }
}
