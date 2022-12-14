using MB.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages
{
    public class ListModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication articleCategoryApplication;

        public ListModel(IArticleCategoryApplication articleCategoryApplication)
        {
            this.articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            ArticleCategories = articleCategoryApplication.GetAll();
        }
        public RedirectToPageResult OnPostRemove(long Id) 
        {
            articleCategoryApplication.Remove(Id);
            return RedirectToPage("./List");
        }
        public RedirectToPageResult OnPostActive(long Id)
        {
            articleCategoryApplication.Activate(Id);
            return RedirectToPage("./List");
        }
    }
}
