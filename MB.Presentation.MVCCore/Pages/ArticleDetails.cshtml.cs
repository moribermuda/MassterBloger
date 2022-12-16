using MB.Application.Contract.Comment;
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryView Article { get; set; }
        private readonly ICommentApplication commentApplication;
        private readonly IArticleQuery articleQuery;

        public ArticleDetailsModel(IArticleQuery articleQuery, ICommentApplication commentApplication)
        {
            this.articleQuery = articleQuery;
            this.commentApplication = commentApplication;
        }


        public void OnGet(long id)
        {
            Article = articleQuery.Get(id);
        }
        public RedirectToPageResult OnPost(AddComment command) 
        {
            commentApplication.Add(command);
            return RedirectToPage("./ArticleDetails");
        }
    }
}
