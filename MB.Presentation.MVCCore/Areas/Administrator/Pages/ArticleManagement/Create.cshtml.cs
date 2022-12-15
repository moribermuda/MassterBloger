using MB.Application.Contract.Article;
using MB.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleManagement
{
    public class CreateModel : PageModel
    {
        public List<SelectListItem> articleCategoryList { get; set; }
        private readonly IArticleCategoryApplication categoryApplication;
        private readonly IArticleApplication articleApplication;
        public CreateModel(IArticleCategoryApplication categoryApplication, IArticleApplication articleApplication)
        {
            this.categoryApplication = categoryApplication;
            this.articleApplication = articleApplication;
        }

        public void OnGet()
        {
            articleCategoryList = categoryApplication.GetAll().Select(
                x => new SelectListItem(x.Title, x.Id.ToString())).ToList();
        }
        public RedirectToPageResult OnPost(CreateArticle command)
        {
            articleApplication.Create(command);
            return RedirectToPage("./List");
        }
    }
}
