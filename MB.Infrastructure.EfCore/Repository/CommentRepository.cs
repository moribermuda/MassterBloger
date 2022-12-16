using MB.Domain.CommentAgg;

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
            context.SaveChanges();
        }
    }
}
