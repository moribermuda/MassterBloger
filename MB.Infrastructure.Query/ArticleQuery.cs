using MB.Domain.CommentAgg;
using MB.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggContext context;

        public ArticleQuery(MasterBloggContext context)
        {
            this.context = context;
        }

        public ArticleQueryView Get(long id)
        {
            return context.articles
                .Include(x => x.ArticleCategory)
                .Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Image = x.Image,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Content = x.Content,
                CommentCont = x.Comments.Count(x => x.Status == Statuses.Confirmed),
                Comments = MapComments(x.Comments.Where(x => x.Status == Statuses.Confirmed))
                }).FirstOrDefault(x => x.Id == id);
        }

        private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
        {
            var resualt = new List<CommentQueryView>();
            foreach(var comment in comments)
            {
                resualt.Add(new CommentQueryView
                {
                    name = comment.Name,
                    Message = comment.Message,
                    CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture),
                });
            }
            return resualt;
        }

        public List<ArticleQueryView> GetArticles()
        {
            return context.articles
                .Include(x => x.Comments)
                .Include(x=>x.ArticleCategory).Select(x=>new ArticleQueryView
            {
                Id= x.Id,
                Title= x.Title,
                ShortDescription= x.ShortDescription,
                Image = x.Image,
                ArticleCategory=x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                CommentCont = x.Comments.Count(x=> x.Status==Statuses.Confirmed),
                }).ToList();
        }
    }
}
