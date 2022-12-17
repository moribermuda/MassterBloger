using MB.Application.Contract.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace MB.Infrastructure.EfCore.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MasterBloggContext context;

        public CommentRepository(MasterBloggContext context)
        {
            this.context = context;
        }

        public void CreatAndSave(Comment entity)
        {
            context.commnts.Add(entity);
            Save();
        }

        public Comment Get(long id)
        {
            return context.commnts.FirstOrDefault(x => x.Id == id);
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

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
