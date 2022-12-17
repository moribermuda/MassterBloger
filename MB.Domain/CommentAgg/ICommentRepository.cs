using MB.Application.Contract.Comment;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        List<CommentViewModel> GetList();
        void CreatAndSave(Comment entity);
        Comment Get(long id);
        void Save();
    }
}
