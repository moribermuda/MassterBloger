using _01_FrameWork.Infrastructure;
using MB.Application.Contract.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MB.Infrastructure.EfCore.Repository
{
    public class CommentRepository :BaseRepository<long,Comment> , ICommentRepository
    {
        private readonly MasterBloggContext context;

        public CommentRepository(MasterBloggContext context) : base(context) 
        {
            this.context = context;
        }


        public List<CommentViewModel> GetList()
        {
           return context.commnts.Include(x=>x.Article).Select(x=>new CommentViewModel
           {
               Id=x.Id,
               Name=x.Name,
               Email=x.Email,
               Message=x.Message,
               Status=x.Status,
               CreationDate=x.CreationDate.ToString(CultureInfo.InvariantCulture),
               Article=x.Article.Title
           }).ToList();
        }

    
    }
}
