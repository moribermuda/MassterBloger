using MB.Application.Contract.Article;
using MB.Domain.ArticleAgg;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleManagement
{
    public class ListModel : PageModel
    {
        private readonly IArticleApplication articleApplication;
        public List<ArticleViewModel> Articles { get; set; } 
        public ListModel(IArticleApplication articleApplication)
        {
            this.articleApplication = articleApplication;
        }

        public void OnGet()
        {
            Articles = articleApplication.GetList();
        }
    }
}
