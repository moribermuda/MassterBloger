using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IArticleQuery articleQuery;

        public IndexModel(IArticleQuery articleQuery)
        {
            this.articleQuery = articleQuery;
        }

        public List<ArticleQueryView> Articles { get; set; }

        public void OnGet()
        {
            Articles = articleQuery.GetArticles();
        }
    }
}