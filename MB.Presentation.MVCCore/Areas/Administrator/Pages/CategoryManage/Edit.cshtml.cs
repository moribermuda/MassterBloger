using MB.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.CategoryManage
{
    public class EditModel : PageModel
    {
        private readonly IArticleCategoryApplication articleCategoryApplication;
        [BindProperty]public RenameArticleCategory category { get; set; }
        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            this.articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(long Id)
        {
            category = articleCategoryApplication.Get(Id);
        }
        public RedirectToPageResult OnPost()
        {
            articleCategoryApplication.Rename(category);
            return RedirectToPage("./List");
        }
    }
}
