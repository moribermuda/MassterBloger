using _01_FrameWork.Infrastructure;
using MB.Application.Contract.Comment;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long , Comment>
    {
        List<CommentViewModel> GetList();
    }
}
